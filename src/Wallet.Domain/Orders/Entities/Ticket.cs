using DDD.Core.DomainObjects;
using Wallet.Domain.Orders.Enums;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Domain.Orders.Entities
{
    public class Ticket : Entity<TicketId>
    {
        private Ticket()
        {
        }

        private Ticket(TicketId id,
                       string cod,
                       string title,
                       string owner,
                       Currency currency,
                       Portfolio portfolio)
            : base(id)
        {
            Cod = cod;
            Title = title;
            Owner = owner;
            Currency = currency;
            Portfolio = portfolio;
        }

        public string Cod { get; set; }

        public string Title { get; set; }

        public string Owner { get; set; }

        public Currency Currency { get; set; }

        public Portfolio Portfolio { get; set; }

        public IReadOnlyList<Order> Orders { get; set; }

        public static Ticket Create(string cod, string title, string owner, Currency currency, Portfolio portfolio)
        {
            return new Ticket(TicketId.Create(),
                              cod,
                              title,
                              owner,
                              currency,
                              portfolio);
        }
    }
}
