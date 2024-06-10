using DDD.Core.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Domain.Orders.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order, OrderId>
    {
    }
}
