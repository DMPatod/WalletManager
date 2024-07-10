using DDD.Core.DomainObjects;
using Wallet.Domain.Users.ValueObjects;

namespace Wallet.Domain.Users
{
    public class User : AggregateRoot<UserId>
    {
    }
}
