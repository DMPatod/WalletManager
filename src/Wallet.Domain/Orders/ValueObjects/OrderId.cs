using DDD.Core.DomainObjects;

namespace Wallet.Domain.Orders.ValueObjects
{
    public class OrderId : ValueObject
    {
        public object Value { get; set; }

        public static OrderId Create(object value)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
