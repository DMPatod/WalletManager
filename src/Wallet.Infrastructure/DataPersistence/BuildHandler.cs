using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wallet.Domain.Orders.Repositories;
using Wallet.Infrastructure.DataPersistence.Sqlite3;
using Wallet.Infrastructure.DataPersistence.Sqlite3.Repositories;

namespace Wallet.Infrastructure.DataPersistence
{
    public static class BuildHandler
    {
        public static IServiceCollection AddDataPersistenceHandler(this IServiceCollection services,
                                                                   IConfiguration configuration)
        {
            services.AddDbContext<Sqlite3DbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();

            return services;
        }
    }
}
