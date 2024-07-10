using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.Sqlite3.Repositories
{
    internal class PortfolioRepository : IPortfolioRepository
    {
        private readonly Sqlite3DbContext _context;

        public PortfolioRepository(Sqlite3DbContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> CreateAsync(Portfolio entity, CancellationToken cancellationToken = default)
        {
            var ct = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ct.Entity;
        }

        public Task DeleteAsync(Portfolio entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio?> FindAsync(PortfolioId id, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Portfolio>();
            return query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<ICollection<Portfolio>> FindAsync(CancellationToken cancellationToken = default)
        {
            var portfolios = _context.Set<Portfolio>();
            return await portfolios.ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(Portfolio entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
