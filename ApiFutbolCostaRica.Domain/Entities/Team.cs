using System.Numerics;

namespace ApiFutbolCostaRica.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int FoundationYear { get; set; }
    public string Stadium { get; set; } = string.Empty;

    // Propiedad de navegación: Un equipo tiene una lista de muchos jugadores
    public ICollection<Player> Players { get; set; } = new List<Player>();
}