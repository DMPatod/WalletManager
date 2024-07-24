using DDD.Core.DomainObjects;

namespace Wallet.Domain.Users.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; set; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }

        public static UserId Create()
        {
            return new UserId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
