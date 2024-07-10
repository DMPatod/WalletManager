using DDD.Core.DomainObjects;

namespace Wallet.Domain.Orders.ValueObjects
{
    public class PortfolioId : ValueObject
    {
        public Guid Value { get; set; }

        private PortfolioId(Guid value)
        {
            Value = value;
        }

        public static PortfolioId Create(Guid value)
        {
            return new PortfolioId(value);
        }

        public static PortfolioId Create()
        {
            return new PortfolioId(Guid.NewGuid());
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
