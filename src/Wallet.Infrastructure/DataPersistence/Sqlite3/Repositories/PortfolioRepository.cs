using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.Sqlite3.Repositories
{
    internal class PortfolioRepository : IPortfolioRepository
    {
        public Task<Portfolio> CreateAsync(Portfolio entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Portfolio entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio?> FindAsync(PortfolioId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Portfolio>> FindAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Portfolio entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
