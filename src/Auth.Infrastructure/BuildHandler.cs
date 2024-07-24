using Auth.Infrastructure.DataPersistence.Sqlite3;
using Auth.Infrastructure.Models;
using Duende.IdentityServer;
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

            services.AddIdentity<AuthUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<Sqlite3DbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(option =>
            {
                option.DefaultScheme = IdentityServerConstants.DefaultCookieAuthenticationScheme;
                option.DefaultChallengeScheme = IdentityServerConstants.DefaultCookieAuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                    options.SlidingExpiration = false;
                });

            services.AddAuthorization();

            return services;
        }
    }
}
