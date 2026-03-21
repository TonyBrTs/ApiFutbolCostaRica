using System.Threading.Tasks;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;
public interface IPlayerRepository
{
    Task<int> RegistrarNuevoJugador(Player player);
    Task<Player> ObtenerJugadorPorId(int id);
    Task<int> ActualizarJugador(Player player);
    Task<int> EliminarJugador(int id);
    Task<IEnumerable<Player>> ObtenerTodosLosJugadores();
}

