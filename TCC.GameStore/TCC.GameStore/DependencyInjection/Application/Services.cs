using Microsoft.Extensions.DependencyInjection;
using TCC.GameStore.Application.Services;
using TCC.GameStore.Application.Services.Interfaces;

namespace TCC.GameStore.Web.DependencyInjection.Application
{
    internal class Services
    {
        public void AddServicesDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
