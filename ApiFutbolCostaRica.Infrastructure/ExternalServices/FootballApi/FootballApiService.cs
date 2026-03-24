using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiFutbolCostaRica.Application.Interfaces;
using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Infrastructure.ExternalServices.FootballApi.Models;
using System.Linq;
using System.IO;

namespace ApiFutbolCostaRica.Infrastructure.ExternalServices.FootballApi;

public class FootballApiService : IFootballApiService
{
    private readonly HttpClient _httpClient;

    public FootballApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<(Team Team, int ApiId)>> GetTeamsByLeague(int leagueId, int season)
    {
        var responseStr = await _httpClient.GetStringAsync($"/teams?league={leagueId}&season={season}");

        var response = System.Text.Json.JsonSerializer.Deserialize<FootballApiResponse<TeamDto>>(responseStr);

        if (response?.Response == null) return Enumerable.Empty<(Team, int)>();

        return response.Response.Select(r => (
            new Team
            {
                Name = r.Team.Name ?? string.Empty,
                FoundationYear = r.Team.Founded ?? 0,
                Stadium = r.Venue?.Name ?? string.Empty,
                LogoUrl = r.Team.Logo ?? string.Empty,
                StadiumImage = r.Venue?.Image ?? string.Empty
            },
            r.Team.Id
        ));
    }

    public async Task<IEnumerable<Player>> GetSquadByTeam(int teamId)
    {
        var response = await _httpClient.GetFromJsonAsync<FootballApiResponse<SquadDto>>($"/players/squads?team={teamId}");

        if (response?.Response == null || !response.Response.Any()) return Enumerable.Empty<Player>();

        var squad = response.Response.First();

        return squad.Players.Select(p => new Player
        {
            Name = p.Name ?? string.Empty,
            Age = p.Age ?? 0,
            Position = p.Position ?? string.Empty,
            Number = p.Number ?? 0,
            PhotoUrl = p.Photo ?? string.Empty,
            Nationality = "Costa Rica" // Dato por defecto si la API no lo da en squad
        });
    }
    public async Task<IEnumerable<Match>> GetFixturesByLeague(int leagueId, int season)
    {
        var response = await _httpClient.GetFromJsonAsync<FootballApiResponse<FixtureDto>>($"/fixtures?league={leagueId}&season={season}");

        if (response?.Response == null || !response.Response.Any()) return Enumerable.Empty<Match>();

        return response.Response.Select(f => new Match
        {
            ExternalId = f.Fixture.Id,
            MatchDate = f.Fixture.Date,
            Referee = f.Fixture.Referee ?? string.Empty,
            Venue = f.Fixture.Venue?.Name ?? string.Empty,
            Status = f.Fixture.Status?.Long ?? "Scheduled",
            HomeTeamGoals = f.Goals.Home ?? 0,
            AwayTeamGoals = f.Goals.Away ?? 0,
            
            // Pasamos los nombres en objetos temporales para que el Handler los busque
            HomeTeam = new Team { Name = f.Teams.Home.Name ?? string.Empty },
            AwayTeam = new Team { Name = f.Teams.Away.Name ?? string.Empty }
        });
    }
}
