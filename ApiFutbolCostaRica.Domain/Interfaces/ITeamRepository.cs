using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;

public interface ITeamRepository
{
    Task<int> RegistrarNuevoEquipo(Team team);
    Task<int> ActualizarEquipo(Team team);
    Task<IEnumerable<Team>> ObtenerTodosLosEquipos();
    Task<Team?> ObtenerEquipoPorId(int id);
    Task<bool> EliminarEquipo(int id);
}
