namespace ApiFutbolCostaRica.Domain.Entities;

public class Match
{
    public int Id { get; set; }
    
    /// <summary>
    /// Unique ID from external API.
    /// </summary>
    public int ExternalId { get; set; }

    /// <summary>
    /// Exact match date and time.
    /// </summary>
    public DateTime MatchDate { get; set; }

    public int HomeTeamId { get; set; }
    public Team? HomeTeam { get; set; }

    public int AwayTeamId { get; set; }
    public Team? AwayTeam { get; set; }

    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }

    /// <summary>
    /// Match status (e.g., Scheduled, Finished).
    /// </summary>
    public string Status { get; set; } = "Scheduled";

    public string Referee { get; set; } = string.Empty;

    public string Venue { get; set; } = string.Empty;
}