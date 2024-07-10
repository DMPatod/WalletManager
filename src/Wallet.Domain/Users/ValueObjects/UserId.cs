using DDD.Core.DomainObjects;

namespace Wallet.Domain.Users.ValueObjects
{
    public class UserId : ValueObject
    {
        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
