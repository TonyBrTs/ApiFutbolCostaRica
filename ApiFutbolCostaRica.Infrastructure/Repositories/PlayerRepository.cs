using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using ApiFutbolCostaRica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiFutbolCostaRica.Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly ApplicationDbContext _context;
    public PlayerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> RegisterNewPlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return player.Id;
    }
    public async Task<Player?> GetPlayerById(int id)
    {
        return await _context.Players
            .Include(p => p.Team)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<IEnumerable<Player>> GetPlayersByName(string name)
    {
        return await _context.Players
            .Include(p => p.Team)
            .Where(p => p.Name.Contains(name))
            .ToListAsync();
    }
    public async Task<int> UpdatePlayer(Player player)
    {
        _context.Players.Update(player);
        return await _context.SaveChangesAsync();
    }
    public async Task<int> DeletePlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
        {
            return 0;
        }
        _context.Players.Remove(player);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        return await _context.Players
            .Include(p => p.Team)
            .ToListAsync();
    }

    public async Task ClearAllPlayers()
    {
        await _context.Players.ExecuteDeleteAsync();
    }
}