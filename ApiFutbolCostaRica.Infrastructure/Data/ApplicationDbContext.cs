using ApiFutbolCostaRica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiFutbolCostaRica.Infrastructure.Persistence;

// Heredar de DbContext es lo que le da los "superpoderes" de base de datos a esta clase
public class ApplicationDbContext : DbContext
{
    // El constructor recibe las opciones (como la cadena de conexión) desde la API web
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Los DbSet representan las tablas reales en la base de datos
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }

    // Aquí podemos configurar reglas especiales de la base de datos si las convenciones no bastan
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ejemplo de configuración fluida (Fluent API): 
        // Obligamos a que el nombre del equipo no pueda ser nulo y tenga un máximo de 100 caracteres
        modelBuilder.Entity<Team>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Las relaciones (1 a muchos) que definimos en el Dominio con las listas, 
        // EF Core las detecta y configura automáticamente aquí. ¡No hay que hacer nada extra!
        // Apagamos el borrado en cascada para el Equipo Local
        modelBuilder.Entity<Match>()
            .HasOne(m => m.HomeTeam)
            .WithMany()
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        // Apagamos el borrado en cascada para el Equipo Visitante
        modelBuilder.Entity<Match>()
            .HasOne(m => m.AwayTeam)
            .WithMany()
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}