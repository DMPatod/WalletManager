using DDD.Core.Repositories;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Domain.Orders.Repositories
{
    public interface IPortfolioRepository : IBaseRepository<Portfolio, PortfolioId>
    {
    }
}
