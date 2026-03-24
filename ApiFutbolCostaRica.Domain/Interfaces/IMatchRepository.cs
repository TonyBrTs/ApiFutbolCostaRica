using ApiFutbolCostaRica.Domain.Entities;

namespace ApiFutbolCostaRica.Domain.Interfaces;

public interface IMatchRepository
{
    /// <summary>Registers a new match.</summary>
    Task<int> RegisterNewMatch(Match match);

    /// <summary>Updates an existing match.</summary>
    Task<int> UpdateMatch(Match match);

    /// <summary>Retrieves a match by its internal ID.</summary>
    Task<Match?> GetMatchById(int id);

    /// <summary>Retrieves a match by its external API ID.</summary>
    Task<Match?> GetMatchByExternalId(int externalId);

    /// <summary>Retrieves all matches.</summary>
    Task<IEnumerable<Match>> GetAllMatches();

    /// <summary>Retrieves matches for a specific date.</summary>
    Task<IEnumerable<Match>> GetMatchesByDate(DateTime date);

    /// <summary>Deletes a match by ID.</summary>
    Task<int> DeleteMatch(int id);
}
