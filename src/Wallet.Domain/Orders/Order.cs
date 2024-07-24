using DDD.Core.DomainObjects;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Enums;
using Wallet.Domain.Orders.ValueObjects;
using Wallet.Domain.Users;
using Wallet.Domain.Users.ValueObjects;

namespace Wallet.Domain.Orders
{
    public class Order : AggregateRoot<OrderId>
    {
        private Order()
        {
            // For EF only.
        }

        private Order(OrderId id,
                      Ticket ticket,
                      DateTime dateTime,
                      OperationType operationType,
                      bool dayTrade,
                      bool completed,
                      double amount,
                      double price,
                      UserId user)
            : base(id)
        {
            Ticket = ticket;
            DateTime = dateTime;
            OperationType = operationType;
            DayTrade = dayTrade;
            Completed = completed;
            Amount = amount;
            Price = price;
            //User = user;
        }

        public virtual Ticket Ticket { get; set; }

        public DateTime DateTime { get; set; }

        public OperationType OperationType { get; set; }

        public bool DayTrade { get; set; }

        public bool Completed { get; set; }

        public double Amount { get; set; }

        public double Price { get; set; }

        public User User { get; set; }

        public static Order Create(Ticket ticket,
                                   DateTime dateTime,
                                   OperationType operationType,
                                   bool dayTrade,
                                   bool completed,
                                   double amount,
                                   double price,
                                   UserId user)
        {
            return new Order(OrderId.Create(),
                             ticket,
                             dateTime,
                             operationType,
                             dayTrade,
                             completed,
                             amount,
                             price,
                             user);
        }
    }
}
