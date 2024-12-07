using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ScreenSound.Banco;

namespace ScreenSound.Integration.Test
{
    public class ScreenSoundWebApplicationFactory : WebApplicationFactory<Program>
    {
        public ScreenSoundContext Context { get; }
        private IServiceScope _scope;
        public ScreenSoundWebApplicationFactory()
        {
            _scope = Services.CreateScope();
            Context = _scope.ServiceProvider.GetRequiredService<ScreenSoundContext>();
        }
    }
}
