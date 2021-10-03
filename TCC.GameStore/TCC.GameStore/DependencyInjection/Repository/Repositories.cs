using Microsoft.Extensions.DependencyInjection;
using TCC.GameStore.Domain.Interfaces.Repositories;
using TCC.GameStore.Infra.Repositories;

namespace TCC.GameStore.Web.DependencyInjection.Repository
{
    internal class Repositories
    {
        public void AddRepositoriesDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
