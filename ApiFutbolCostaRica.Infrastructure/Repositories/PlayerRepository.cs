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
}