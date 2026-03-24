using System.Threading.Tasks;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;
public interface IPlayerRepository
{
    /// <summary>Registers a new player.</summary>
    Task<int> RegisterNewPlayer(Player player);

    /// <summary>Gets a player by their ID, including team info.</summary>
    Task<Player?> GetPlayerById(int id);

    /// <summary>Searches for players by name.</summary>
    Task<IEnumerable<Player>> GetPlayersByName(string name);

    /// <summary>Updates an existing player.</summary>
    Task<int> UpdatePlayer(Player player);

    /// <summary>Deletes a player by ID.</summary>
    Task<int> DeletePlayer(int id);

    /// <summary>Retrieves all players.</summary>
    Task<IEnumerable<Player>> GetAllPlayers();

    /// <summary>Clears all players from the database.</summary>
    Task ClearAllPlayers();
}

