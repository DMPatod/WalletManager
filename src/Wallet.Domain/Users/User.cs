using DDD.Core.DomainObjects;
using Wallet.Domain.Users.ValueObjects;

namespace Wallet.Domain.Users
{
    public class User : AggregateRoot<UserId>
    {
        public string Email { get; set; }

        public User()
        {
        }

        public User(UserId id, string email) : base(id)
        {
            Email = email;
        }
    }
}
