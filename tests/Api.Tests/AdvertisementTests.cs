using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Board.Contracts.Contexts.Advertisements;
using Xunit;

namespace Api.Tests;

public class AdvertisementTests : IClassFixture<BoardWebApplicationFactory>
{
    private readonly BoardWebApplicationFactory _webAppFactory;

    public AdvertisementTests(BoardWebApplicationFactory webAppFactory)
    {
        _webAppFactory = webAppFactory;
    }
    
    [Fact]
    public async Task Advert_GetById_Success()
    {
        // Arrange
        var httpClient = _webAppFactory.CreateClient();
        var id = DataSeedHelper.TestAdvertId;

        // Act
        var response = await httpClient.GetAsync($"Advertisement/{id}");

        // Assert
            
        Assert.NotNull(response);

        var result = await response.Content.ReadFromJsonAsync<InfoAdvertisementDto>();

        Assert.NotNull(result);

        Assert.Equal("Какое-то название", result!.Title);
        Assert.Equal("Какое-то описание", result.Description);
        Assert.Equal("Какой-то адрес", result.Address);
        Assert.True(result.IsActive);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}