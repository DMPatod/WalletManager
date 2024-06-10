using DDD.Core.DomainObjects;

namespace Wallet.Domain.Orders.ValueObjects
{
    public class TicketId : ValueObject
    {
        public TicketId(string id)
        {
        }

        public object Value { get; set; }

        public static TicketId Create(object value)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
