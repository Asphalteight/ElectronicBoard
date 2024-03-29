using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Board.Host.Migrator;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
            services.AddServices(hostContext.Configuration)).Build();

        await MigrateDatabaseAsync(host.Services);
        await host.RunAsync();
    }

    private static async Task MigrateDatabaseAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DbContextMigration>();

        await context.Database.MigrateAsync();
    }
}