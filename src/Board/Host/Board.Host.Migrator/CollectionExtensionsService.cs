using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Board.Host.Migrator;

/// <summary>
/// Расширение для добавления сервисов.
/// </summary>
public static class CollectionExtensionsService
{
    /// <summary>
    /// Добавление сервисов.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDbConnections(configuration);
        
        return services;
    }

    /// <summary>
    /// Конфигурация подключения к базе данных.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static IServiceCollection ConfigureDbConnections(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresBoardDb");
        services.AddDbContext<DbContextMigration>(options => options.UseNpgsql(connectionString));

        return services;
    }
}