using DDD.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Wallet.Application
{
    public static class BuildHandler
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddDefaultMessageHandler(typeof(BuildHandler).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies([typeof(BuildHandler).Assembly]));

            return services;
        }
    }
}
