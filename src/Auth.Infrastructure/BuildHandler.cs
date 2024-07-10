using Auth.Infrastructure.DataPersistence.Sqlite3;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure
{
    public static class BuildHandler
    {
        public static IServiceCollection AddWalletInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Sqlite3DbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<Sqlite3DbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
