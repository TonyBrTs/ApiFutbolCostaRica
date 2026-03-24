using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;

public interface IMatchRepository
{
    Task<int> RegisterNewMatch(Match match);
    Task<int> UpdateMatch(Match match);
    Task<Match?> GetMatchById(int id);
    Task<Match?> GetMatchByExternalId(int externalId);
    Task<IEnumerable<Match>> GetAllMatches();
    Task<IEnumerable<Match>> GetMatchesByDate(DateTime date);
    Task<int> DeleteMatch(int id);
}
