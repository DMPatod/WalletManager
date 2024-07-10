using Moq;
using Wallet.Domain.Orders;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Enums;

namespace UnitTest.Wallet.Domain.Orders
{
    public class OrderTests
    {
        [Fact]
        public void Create_ShouldCreateOrder()
        {
            var ticket = Mock.Of<Ticket>();

            var dateTime = DateTime.Now;
            var operationType = OperationType.Outcome;
            var amount = 100.0;
            var price = 10.0;
            var dayTrade = true;
            var completed = true;

            var order = Order.Create(ticket,
                                     dateTime,
                                     operationType,
                                     dayTrade,
                                     completed,
                                     amount,
                                     price);

            Assert.NotNull(order);
            Assert.Equal(ticket, order.Ticket);
            Assert.Equal(dateTime, order.DateTime);
            Assert.Equal(operationType, order.OperationType);
            Assert.Equal(dayTrade, order.DayTrade);
            Assert.Equal(completed, order.Completed);
            Assert.Equal(amount, order.Amount);
            Assert.Equal(price, order.Price);
        }
    }
}
