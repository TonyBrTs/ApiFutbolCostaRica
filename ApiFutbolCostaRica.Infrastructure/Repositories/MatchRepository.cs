using ApiFutbolCostaRica.Domain.Entities;
using ApiFutbolCostaRica.Domain.Interfaces;
using ApiFutbolCostaRica.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiFutbolCostaRica.Infrastructure.Repositories;

public class MatchRepository : IMatchRepository
{
    private readonly ApplicationDbContext _context;

    public MatchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> RegisterNewMatch(Match match)
    {
        _context.Matches.Add(match);
        await _context.SaveChangesAsync();
        return match.Id;
    }

    public async Task<int> UpdateMatch(Match match)
    {
        _context.Matches.Update(match);
        await _context.SaveChangesAsync();
        return match.Id;
    }

    public async Task<Match?> GetMatchById(int id)
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Match?> GetMatchByExternalId(int externalId)
    {
        return await _context.Matches
            .FirstOrDefaultAsync(m => m.ExternalId == externalId);
    }

    public async Task<IEnumerable<Match>> GetAllMatches()
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .ToListAsync();
    }

    public async Task<IEnumerable<Match>> GetMatchesByDate(DateTime date)
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Where(m => m.MatchDate.Date == date.Date)
            .ToListAsync();
    }

    public async Task<int> DeleteMatch(int id)
    {
        var match = await _context.Matches.FindAsync(id);
        if (match == null) return 0;

        _context.Matches.Remove(match);
        return await _context.SaveChangesAsync();
    }
}
