using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Configuration;

public class TrainContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("trainDB");
    }
    public DbSet<Train> Trains { get; set; }
    public DbSet<Vagon> Vagons { get; set; }
}
