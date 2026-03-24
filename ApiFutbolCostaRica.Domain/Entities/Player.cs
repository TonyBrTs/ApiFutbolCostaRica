namespace ApiFutbolCostaRica.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public int Age { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public int? Number { get; set; }

    /// <summary>
    /// Foreign key for the associated Team.
    /// </summary>
    public int? TeamId { get; set; }

    /// <summary>
    /// Navigation property for the associated Team.
    /// </summary>
    public Team? Team { get; set; }
}