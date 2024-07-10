using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Orders;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.Sqlite3.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly Sqlite3DbContext _context;

        public OrderRepository(Sqlite3DbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var ct = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ct.Entity;
        }

        public Task DeleteAsync(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> FindAsync(OrderId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Order>> FindAsync(CancellationToken cancellationToken = default)
        {
            var orders = _context.Set<Order>();
            return await orders.ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
