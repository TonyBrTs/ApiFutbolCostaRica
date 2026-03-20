namespace ApiFutbolCostaRica.Domain.Entities;

public class Match
{
    public int Id { get; set; }
    
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

    // Estado del partido: "Programado", "En Curso", "Finalizado"
    public string Status { get; set; } = "Programado"; 
}