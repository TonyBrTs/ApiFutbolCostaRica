using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;

public interface IMatchRepository
{
    Task<int> RegistrarNuevoPartido(Match match);
    Task<int> ActualizarPartido(Match match);
    Task<Match?> ObtenerPartidoPorId(int id);
    Task<Match?> ObtenerPartidoPorIdExterno(int externalId);
    Task<IEnumerable<Match>> ObtenerTodosLosPartidos();
    Task<IEnumerable<Match>> ObtenerPartidosPorFecha(DateTime date);
    Task<int> EliminarPartido(int id);
}
