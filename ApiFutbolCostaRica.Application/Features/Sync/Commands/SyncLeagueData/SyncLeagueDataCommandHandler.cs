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
        var externalResults = await _footballApiService.GetTeamsByLeague(request.LeagueId, request.Season);

        foreach (var (team, apiId) in externalResults)
        {
            var existingTeams = await _teamRepository.GetTeamsByName(team.Name);
            var existingTeam = existingTeams.FirstOrDefault();

            int internalTeamId;

            if (existingTeam == null)
            {
                internalTeamId = await _teamRepository.RegisterNewTeam(team);
            }
            else
            {
                if (string.IsNullOrEmpty(existingTeam.LogoUrl))
                {
                    existingTeam.LogoUrl = team.LogoUrl;
                    existingTeam.StadiumImage = team.StadiumImage;
                    await _teamRepository.UpdateTeam(existingTeam);
                }
                internalTeamId = existingTeam.Id;
            }

            await Task.Delay(5000, cancellationToken);

            var externalPlayers = await _footballApiService.GetSquadByTeam(apiId);

            foreach (var player in externalPlayers)
            {
                player.TeamId = internalTeamId;
                
                var playerSearchResults = await _playerRepository.GetPlayersByName(player.Name);
                var existingPlayer = playerSearchResults.FirstOrDefault(p => p.TeamId == internalTeamId);

                if (existingPlayer == null)
                {
                    await _playerRepository.RegisterNewPlayer(player);
                }
                else if (string.IsNullOrEmpty(existingPlayer.PhotoUrl))
                {
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
