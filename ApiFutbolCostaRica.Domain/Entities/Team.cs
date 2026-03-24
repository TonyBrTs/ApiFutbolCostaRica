using System.Numerics;

namespace ApiFutbolCostaRica.Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int FoundationYear { get; set; }
    public string Stadium { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public string StadiumImage { get; set; } = string.Empty;

    // Navigation property: A team has a list of many players
    public ICollection<Player> Players { get; set; } = new List<Player>();
}