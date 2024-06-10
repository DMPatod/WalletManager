using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.Sqlite3.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        public Task<Ticket> CreateAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket?> FindAsync(TicketId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Ticket>> FindAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
