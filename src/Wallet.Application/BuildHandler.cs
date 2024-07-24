using DDD.Core.Handlers;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Wallet.Application
{
    public static class BuildHandler
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            [
                typeof(BuildHandler).Assembly,
                typeof(Auth.Application.BuildHandler).Assembly
            ]));

            services.TryAddTransient<IMessageHandler, DefaultMessageHandler>();

            return services;
        }
    }
}
