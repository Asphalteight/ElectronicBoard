using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess;

/// <summary>
/// Контекст БД
/// </summary>
public class BoardDbContext : DbContext
{
    /// <summary>
    /// Инициализирует экземпляр <see cref="BoardDbContext"/>
    /// </summary>
    /// <param name="options"></param>
    public BoardDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => 
            t.GetInterfaces().Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
    }
} 