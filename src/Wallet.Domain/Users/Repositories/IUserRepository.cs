using Wallet.Domain.Users.ValueObjects;

namespace Wallet.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> FindAsync(UserId id, CancellationToken cancellationToken);
        public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
