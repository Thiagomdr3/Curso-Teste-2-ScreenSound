using ScreenSound.API.Requests;
using System.Net;
using System.Net.Http.Json;

namespace ScreenSound.Integration.Test;


public class Artista_POST:IClassFixture<ScreenSoundWebApplicationFactory>
{
    private readonly ScreenSoundWebApplicationFactory _factory;
    public Artista_POST(ScreenSoundWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Cadastra_Artista()
    {
        //Arrange
        using var client = _factory.CreateClient();
        var artista = new ArtistaRequest("João Silva", "Nascido no Espirito Santo");

        //Act
        var response = await client.PostAsJsonAsync("/Artistas", artista);

        //Assert
        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}