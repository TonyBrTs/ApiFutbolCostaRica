using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using ApiFutbolCostaRica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiFutbolCostaRica.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> RegistrarNuevoEquipo(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team.Id;
    }

    public async Task<int> ActualizarEquipo(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
        return team.Id;
    }

    public async Task<IEnumerable<Team>> ObtenerTodosLosEquipos()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<Team?> ObtenerEquipoPorId(int id)
    {
        return await _context.Teams.FindAsync(id);
    }

    public async Task<bool> EliminarEquipo(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return false;

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return true;
    }
}
