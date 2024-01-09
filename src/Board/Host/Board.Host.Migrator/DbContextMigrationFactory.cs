using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Board.Host.Migrator;

/// <summary>
/// Фабрика контекста.
/// </summary>
public class DbContextMigrationFactory : IDesignTimeDbContextFactory<DbContextMigration>
{
    /// <inheritdoc/>
    public DbContextMigration CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var config = builder.Build();
        var connection = config.GetConnectionString("PostgresBoardDb");

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<DbContextMigration>();
        dbContextOptionsBuilder.UseNpgsql(connection);
        return new DbContextMigration(dbContextOptionsBuilder.Options);
    }
}