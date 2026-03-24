namespace ApiFutbolCostaRica.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty; // Ej: "Portero", "Defensa"
    public string Nationality { get; set; } = string.Empty;
    public int Age { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public int? Number { get; set; }

    // Relationship with Team (Foreign Key) - Now optional
    public int? TeamId { get; set; }

    // Navigation property: A player belongs to a single team
    public Team? Team { get; set; }
}