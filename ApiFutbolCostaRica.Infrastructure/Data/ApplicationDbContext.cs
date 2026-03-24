using ApiFutbolCostaRica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiFutbolCostaRica.Infrastructure.Persistence;

// Inheriting from DbContext gives this class database "superpowers"
public class ApplicationDbContext : DbContext
{
    // The constructor receives options (like the connection string) from the web API
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets represent actual tables in the database
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }

    // Here we can configure special database rules if conventions are not enough
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fluent API configuration example:
        // Force the team name to be non-null and have a maximum of 100 characters
        modelBuilder.Entity<Team>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        // The relationships (1-to-many) defined in the Domain with lists,
        // EF Core detects and configures them automatically here. No extra work needed!
        // Disable cascade delete for the Home Team
        modelBuilder.Entity<Match>()
            .HasOne(m => m.HomeTeam)
            .WithMany()
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        // Disable cascade delete for the Away Team
        modelBuilder.Entity<Match>()
            .HasOne(m => m.AwayTeam)
            .WithMany()
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}