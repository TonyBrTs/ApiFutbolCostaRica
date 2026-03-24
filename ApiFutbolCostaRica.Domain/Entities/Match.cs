namespace ApiFutbolCostaRica.Domain.Entities;

public class Match
{
    public int Id { get; set; }
    
    // ID único de la API externa (v3.football.api-sports.io)
    public int ExternalId { get; set; }

    // Fecha y hora exacta del partido
    public DateTime MatchDate { get; set; }

    // --- Relación con el Equipo Local ---
    public int HomeTeamId { get; set; }
    public Team? HomeTeam { get; set; }

    // --- Relación con el Equipo Visitante ---
    public int AwayTeamId { get; set; }
    public Team? AwayTeam { get; set; }

    // Marcador
    public int HomeTeamGoals { get; set; }
    public int AwayTeamGoals { get; set; }

    // Estado del partido: "Programado", "En Curso", "Finalizado", etc.
    public string Status { get; set; } = "Programado";

    // Nombre del árbitro
    public string Referee { get; set; } = string.Empty;

    // Nombre del estadio donde se juega
    public string Venue { get; set; } = string.Empty;
}