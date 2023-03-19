using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Interfaces;

/// <summary>
/// Конфигуратор контекста.
/// </summary>
/// <typeparam name="TContext"></typeparam>
public interface IDbContextOptionsConfigurator<TContext> where TContext : DbContext
{
    void Configure(DbContextOptionsBuilder<TContext> options);
}