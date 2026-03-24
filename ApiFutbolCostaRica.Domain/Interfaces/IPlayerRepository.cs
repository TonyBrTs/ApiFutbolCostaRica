using System.Threading.Tasks;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;
public interface IPlayerRepository
{
    Task<int> RegisterNewPlayer(Player player);
    Task<Player?> GetPlayerById(int id);
    Task<IEnumerable<Player>> GetPlayersByName(string name);
    Task<int> UpdatePlayer(Player player);
    Task<int> DeletePlayer(int id);
    Task<IEnumerable<Player>> GetAllPlayers();
    Task ClearAllPlayers();
}

