using System.Threading.Tasks;
using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;
public interface IPlayerRepository
{
    Task<int> RegistrarNuevoJugador(Player player);
    Task<Player?> ObtenerJugadorPorId(int id);
    Task<IEnumerable<Player>> ObtenerJugadorPorNombre(string name);
    Task<int> ActualizarJugador(Player player);
    Task<int> EliminarJugador(int id);
    Task<IEnumerable<Player>> ObtenerTodosLosJugadores();
}

