using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Infrastructure.DataPersistence;

namespace Wallet.Infrastructure
{
    public static class BuildHandler
    {
        public static IServiceCollection AddAuthInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataPersistenceHandler(configuration);

            return services;
        }
    }
}
