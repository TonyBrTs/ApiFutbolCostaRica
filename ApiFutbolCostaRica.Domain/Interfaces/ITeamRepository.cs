using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;

public interface ITeamRepository
{
    Task<int> RegisterNewTeam(Team team);
    Task<int> UpdateTeam(Team team);
    Task<IEnumerable<Team>> GetAllTeams();
    Task<Team?> GetTeamById(int id);
    Task<IEnumerable<Team>> GetTeamsByName(string name);
    Task<bool> DeleteTeam(int id);
    Task ClearAllTeams();
}
