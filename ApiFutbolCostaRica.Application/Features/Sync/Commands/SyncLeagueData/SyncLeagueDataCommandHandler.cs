using ApiFutbolCostaRica.Application.Interfaces;
using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.Application.Features.Sync.Commands.SyncLeagueData;

public class SyncLeagueDataCommandHandler : IRequestHandler<SyncLeagueDataCommand, bool>
{
    private readonly IFootballApiService _footballApiService;
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;

    public SyncLeagueDataCommandHandler(
        IFootballApiService footballApiService,
        ITeamRepository teamRepository,
        IPlayerRepository playerRepository)
    {
        _footballApiService = footballApiService;
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
    }

    public async Task<bool> Handle(SyncLeagueDataCommand request, CancellationToken cancellationToken)
    {
        // 1. Obtener equipos desde la API externa
        var externalResults = await _footballApiService.GetTeamsByLeague(request.LeagueId, request.Season);

        foreach (var (team, apiId) in externalResults)
        {
            // 2. Buscar si el equipo ya existe en la BD
            var existingTeams = await _teamRepository.GetTeamsByName(team.Name);
            var existingTeam = existingTeams.FirstOrDefault();

            int internalTeamId;

            if (existingTeam == null)
            {
                internalTeamId = await _teamRepository.RegisterNewTeam(team);
            }
            else
            {
                // Solo actualizamos si le falta la información visual nueva
                if (string.IsNullOrEmpty(existingTeam.LogoUrl))
                {
                    existingTeam.LogoUrl = team.LogoUrl;
                    existingTeam.StadiumImage = team.StadiumImage;
                    await _teamRepository.UpdateTeam(existingTeam);
                }
                internalTeamId = existingTeam.Id;
            }

            // SEGURIDAD: 5 segundos entre equipos para evitar el límite de frecuencia (10/min)
            await Task.Delay(5000, cancellationToken);

            // 3. Obtener plantilla desde la API
            var externalPlayers = await _footballApiService.GetSquadByTeam(apiId);

            foreach (var player in externalPlayers)
            {
                player.TeamId = internalTeamId;
                
                // 4. Buscar si el jugador existe en este equipo
                var playerSearchResults = await _playerRepository.GetPlayersByName(player.Name);
                var existingPlayer = playerSearchResults.FirstOrDefault(p => p.TeamId == internalTeamId);

                if (existingPlayer == null)
                {
                    await _playerRepository.RegisterNewPlayer(player);
                }
                else if (string.IsNullOrEmpty(existingPlayer.PhotoUrl))
                {
                    // Actualizar solo si le faltan los datos nuevos
                    existingPlayer.PhotoUrl = player.PhotoUrl;
                    existingPlayer.Number = player.Number;
                    existingPlayer.Position = player.Position;
                    existingPlayer.Age = player.Age;
                    
                    await _playerRepository.UpdatePlayer(existingPlayer);
                }
            }
        }

        return true;
    }
}
