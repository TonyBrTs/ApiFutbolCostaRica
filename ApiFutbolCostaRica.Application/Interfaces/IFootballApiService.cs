using ApiFutbolCostaRica.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiFutbolCostaRica.Application.Interfaces;

public interface IFootballApiService
{
    Task<IEnumerable<(Team Team, int ApiId)>> GetTeamsByLeague(int leagueId, int season);
    Task<IEnumerable<Player>> GetSquadByTeam(int apiTeamId);
    Task<IEnumerable<Match>> GetFixturesByLeague(int leagueId, int season);
}
