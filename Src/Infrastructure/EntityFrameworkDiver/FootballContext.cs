using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkDiver;
public partial class FootballContext : DbContext
{
    //TODO: se instala nuget Microsoft.Data.SqlClient
    //se crea clase partial y protected
    //se crea el constructor vacio
    public FootballContext() { }
    public FootballContext(DbContextOptions<FootballContext> options): base(options)
    {
    }

    public DbSet<Manager> Managers { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Referee> Referees { get; set; }
    public DbSet<Match> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
