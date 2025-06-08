using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using ZooHelp.Domain.SpeciesContext.Entities;
using ZooHelp.Domain.VolunteerContext.AgregateRoot;
using ZooHelp.Infrastructure.Configurations;

namespace ZooHelp.Infrastructure;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    private readonly PostgreSqlConnectionConfig _postgresqlConfig =
        configuration.GetSection("PostgreSqlConnection").Get<PostgreSqlConnectionConfig>()!;

    public DbSet<VolunteerEntity> Volunteers => Set<VolunteerEntity>();

    public DbSet<SpeciesEntity> Species => Set<SpeciesEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_postgresqlConfig.GetConnectionString());
        optionsBuilder.UseSnakeCaseNamingConvention();
        optionsBuilder.UseLoggerFactory(
            LoggerFactory.Create(build => build.AddConsole())
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}