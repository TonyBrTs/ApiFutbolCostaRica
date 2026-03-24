using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;

public interface ITeamRepository
{
    /// <summary>Registers a new team in the database.</summary>
    Task<int> RegisterNewTeam(Team team);

    /// <summary>Updates an existing team's information.</summary>
    Task<int> UpdateTeam(Team team);

    /// <summary>Retrieves all teams including their players.</summary>
    Task<IEnumerable<Team>> GetAllTeams();

    /// <summary>Retrieves a team by its ID, including players.</summary>
    Task<Team?> GetTeamById(int id);

    /// <summary>Searches for teams by name.</summary>
    Task<IEnumerable<Team>> GetTeamsByName(string name);

    /// <summary>Deletes a team from the database.</summary>
    Task<bool> DeleteTeam(int id);

    /// <summary>Clears all teams from the database.</summary>
    Task ClearAllTeams();
}
