using ApiFutbolCostaRica.Application.Interfaces;
using ApiFutbolCostaRica.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.Application.Features.Sync.Commands.SyncMatches;

public class SyncMatchesCommandHandler : IRequestHandler<SyncMatchesCommand, bool>
{
    private readonly IFootballApiService _footballApiService;
    private readonly IMatchRepository _matchRepository;
    private readonly ITeamRepository _teamRepository;

    public SyncMatchesCommandHandler(
        IFootballApiService footballApiService,
        IMatchRepository matchRepository,
        ITeamRepository teamRepository)
    {
        _footballApiService = footballApiService;
        _matchRepository = matchRepository;
        _teamRepository = teamRepository;
    }

    public async Task<bool> Handle(SyncMatchesCommand request, CancellationToken cancellationToken)
    {
        var fixtures = await _footballApiService.GetFixturesByLeague(request.LeagueId, request.Season);

        foreach (var fixture in fixtures)
        {
            var existingMatch = await _matchRepository.GetMatchByExternalId(fixture.ExternalId);

            var homeTeams = await _teamRepository.GetTeamsByName(fixture.HomeTeam!.Name);
            var homeTeam = homeTeams.FirstOrDefault();

            var awayTeams = await _teamRepository.GetTeamsByName(fixture.AwayTeam!.Name);
            var awayTeam = awayTeams.FirstOrDefault();

            // Si los equipos no existen localmente, no podemos registrar el partido
            // Se debe haber corrido antes la sincronización de liga (Equipos).
            if (homeTeam == null || awayTeam == null)
            {
                continue;
            }

            if (existingMatch == null)
            {
                fixture.HomeTeamId = homeTeam.Id;
                fixture.AwayTeamId = awayTeam.Id;
                
                // Evitamos que EF intente insertar los equipos temporales de nuevo
                fixture.HomeTeam = null;
                fixture.AwayTeam = null;

                await _matchRepository.RegisterNewMatch(fixture);
            }
            else
            {
                // Solo actualizamos lo que podría cambiar (marcador, estado, etc.)
                existingMatch.MatchDate = fixture.MatchDate;
                existingMatch.Status = fixture.Status;
                existingMatch.HomeTeamGoals = fixture.HomeTeamGoals;
                existingMatch.AwayTeamGoals = fixture.AwayTeamGoals;
                existingMatch.Referee = fixture.Referee;
                existingMatch.Venue = fixture.Venue;
                
                await _matchRepository.UpdateMatch(existingMatch);
            }
        }

        return true;
    }
}
