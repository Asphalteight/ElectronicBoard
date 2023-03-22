using Board.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Board.Host.Migrator;

/// <summary>
/// Контекст базы данных для мигратора.
/// </summary>
public class DbContextMigration : BoardDbContext
{
    public DbContextMigration(DbContextOptions options) : base(options)
    {
    }
}