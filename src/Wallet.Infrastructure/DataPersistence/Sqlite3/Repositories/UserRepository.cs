using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Users;
using Wallet.Domain.Users.Repositories;
using Wallet.Domain.Users.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.Sqlite3.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly Sqlite3DbContext _context;

        public UserRepository(Sqlite3DbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindAsync(UserId id, CancellationToken cancellationToken)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }
    }
}
