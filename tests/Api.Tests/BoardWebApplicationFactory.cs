using System.Linq;
using Board.Infrastructure.DataAccess;
using Board.Infrastructure.DataAccess.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Api.Tests;

/// <summary>
/// Фабрика тестового варианта сервиса.
/// </summary>
public class BoardWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(IDbContextOptionsConfigurator<BoardDbContext>));

            services.Remove(descriptor!);

            services.AddSingleton<IDbContextOptionsConfigurator<BoardDbContext>, TestBoardDbContextConfiguration>();
                
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<BoardDbContext>();

            db.Database.EnsureCreated();
            DataSeedHelper.InitializeDbForTests(db);
        });
    }

    /// <summary>
    /// Создание контекста тестовой БД.
    /// </summary>
    /// <returns></returns>
    public BoardDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<BoardDbContext>();
        optionsBuilder.UseInMemoryDatabase(TestBoardDbContextConfiguration.InMemoryDatabaseName);
        optionsBuilder.EnableSensitiveDataLogging();
        var dbContext = new BoardDbContext(optionsBuilder.Options);
        return dbContext;
    }
}