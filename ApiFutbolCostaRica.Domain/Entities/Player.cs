namespace ApiFutbolCostaRica.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty; // Ej: "Portero", "Defensa"
    public string Nationality { get; set; } = string.Empty;
    public int Age { get; set; }
    // Relación con el Equipo (Llave Foránea) - Ahora opcional
    public int? TeamId { get; set; }

    // Propiedad de navegación: Un jugador pertenece a un solo equipo
    public Team? Team { get; set; }
}