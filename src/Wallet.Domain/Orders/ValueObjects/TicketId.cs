using DDD.Core.DomainObjects;

namespace Wallet.Domain.Orders.ValueObjects
{
    public class TicketId : ValueObject
    {
        private TicketId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; set; }

        public static TicketId Create(Guid value)
        {
            return new TicketId(value);
        }

        internal static TicketId Create()
        {
            return new TicketId(Guid.NewGuid());
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
