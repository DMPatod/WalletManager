using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.Sqlite3.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private readonly Sqlite3DbContext _context;

        public TicketRepository(Sqlite3DbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> CreateAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            var ct = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ct.Entity;
        }

        public Task DeleteAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket?> FindAsync(TicketId id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Ticket>().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task<ICollection<Ticket>> FindAsync(CancellationToken cancellationToken = default)
        {
            var tickets = _context.Set<Ticket>();
            return await tickets.ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(Ticket entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
