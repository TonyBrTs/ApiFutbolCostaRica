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
    public async Task<int> RegistrarNuevoJugador(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return player.Id;
    }
    public async Task<Player?> ObtenerJugadorPorId(int id)
    {
        return await _context.Players.FindAsync(id);
    }
    public async Task<IEnumerable<Player>> ObtenerJugadorPorNombre(string name)
    {
        return await _context.Players
            .Where(p => p.Name.Contains(name))
            .ToListAsync();
    }
    public async Task<int> ActualizarJugador(Player player)
    {
        _context.Players.Update(player);
        return await _context.SaveChangesAsync();
    }
    public async Task<int> EliminarJugador(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null)
        {
            return 0;
        }
        _context.Players.Remove(player);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Player>> ObtenerTodosLosJugadores()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task LimpiarTodosLosJugadores()
    {
        await _context.Players.ExecuteDeleteAsync();
    }
}