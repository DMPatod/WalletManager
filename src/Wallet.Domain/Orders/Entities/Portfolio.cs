using DDD.Core.DomainObjects;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Domain.Orders.Entities
{
    public class Portfolio : Entity<PortfolioId>
    {
        private Portfolio()
        {
        }

        private Portfolio(PortfolioId id, string title)
            : base(id)
        {
            Title = title;
        }

        public string Title { get; set; }

        public IList<Ticket> Tickets { get; set; }

        public static Portfolio Create(string title)
        {
            throw new NotImplementedException();
        }
    }
}
