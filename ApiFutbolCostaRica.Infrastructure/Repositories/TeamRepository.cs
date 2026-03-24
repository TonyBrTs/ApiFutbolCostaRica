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

    public async Task<int> RegisterNewTeam(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team.Id;
    }

    public async Task<int> UpdateTeam(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
        return team.Id;
    }

    public async Task<IEnumerable<Team>> GetAllTeams()
    {
        return await _context.Teams
            .Include(t => t.Players)
            .ToListAsync();
    }

    public async Task<Team?> GetTeamById(int id)
    {
        return await _context.Teams
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Team>> GetTeamsByName(string name)
    {
        return await _context.Teams
            .Include(t => t.Players)
            .Where(t => t.Name.Contains(name))
            .ToListAsync();
    }

    public async Task<bool> DeleteTeam(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return false;

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task ClearAllTeams()
    {
        await _context.Teams.ExecuteDeleteAsync();
    }
}
