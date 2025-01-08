using EVChargingPort.API.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVChargingPort.API.Infrastructure.DbContexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();
    }
}