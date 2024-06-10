using DDD.Core.DomainObjects;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Enums;
using Wallet.Domain.Orders.ValueObjects;

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
                      double price)
            : base(id)
        {
            Ticket = ticket;
            DateTime = dateTime;
            OperationType = operationType;
            DayTrade = dayTrade;
            Completed = completed;
            Amount = amount;
            Price = price;
        }

        public Ticket Ticket { get; set; }

        public DateTime DateTime { get; set; }

        public OperationType OperationType { get; set; }

        public bool DayTrade { get; set; }

        public bool Completed { get; set; }

        public double Amount { get; set; }

        public double Price { get; set; }

        public static Order Create(Ticket value, DateTime dateTime, OperationType type, double amount, double price)
        {
            throw new NotImplementedException();
        }
    }
}
