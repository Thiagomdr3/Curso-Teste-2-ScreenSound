using Microsoft.AspNetCore.Builder;
using ScreenSound.API.Requests;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Integration.Test
{
    public class Artista_PUT:IClassFixture<ScreenSoundWebApplicationFactory>
    {
        private readonly ScreenSoundWebApplicationFactory _factory;
        public Artista_PUT(ScreenSoundWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Atualiza_Artista()
        {
            //Arrange
            var artistaExistente = _factory.Context.Artistas.FirstOrDefault();
            using var client = _factory.CreateClient();

            if (artistaExistente == null)
            {
                var artista = new ArtistaRequest("João Silva", "Nascido no Espirito Santo");
                artistaExistente = new Artista(artista.nome, artista.bio);
                await client.PostAsJsonAsync("/Artistas", artista);
            }

            artistaExistente.Nome = "Tiririca";

            //Act
            var response = await client.PutAsJsonAsync("/Artistas", artistaExistente);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
