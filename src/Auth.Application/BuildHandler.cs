using Microsoft.Extensions.DependencyInjection;

namespace Auth.Application
{
    public static class BuildHandler
    {
        public static IServiceCollection AddAuthApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
