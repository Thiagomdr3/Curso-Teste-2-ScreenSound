using ScreenSound.API.Requests;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Integration.Test
{
    public class Artista_GET:IClassFixture<ScreenSoundWebApplicationFactory>
    {
        private readonly ScreenSoundWebApplicationFactory _factory;
        public Artista_GET(ScreenSoundWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Recupera_Artista_Por_Id()
        {
            //Arrange

            var artistaExistente = _factory.Context.Artistas.FirstOrDefault();

            if (artistaExistente is null)
            {
                artistaExistente = new Artista("João Silva", "Nascido em São Paulo");
                _factory.Context.Artistas.Add(artistaExistente);
                _factory.Context.SaveChanges();
            }
            using var client = _factory.CreateClient();

            //Act
            var response = await client.GetFromJsonAsync<Artista>("/Artistas/"+artistaExistente.Id);

            //Assert

            Assert.NotNull(response);
            Assert.Equal(artistaExistente.Id, response.Id);
            Assert.Equal(artistaExistente.Nome, response.Nome);
        }

    }
}
