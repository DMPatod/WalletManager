using Moq;
using Wallet.Domain.Orders;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Enums;
using Wallet.Domain.Users.ValueObjects;

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
            var user = UserId.Create(Guid.NewGuid());

            var order = Order.Create(ticket,
                                     dateTime,
                                     operationType,
                                     dayTrade,
                                     completed,
                                     amount,
                                     price,
                                     user);

            Assert.NotNull(order);
            Assert.Equal(ticket, order.Ticket);
            Assert.Equal(dateTime, order.DateTime);
            Assert.Equal(operationType, order.OperationType);
            Assert.Equal(dayTrade, order.DayTrade);
            Assert.Equal(completed, order.Completed);
            Assert.Equal(amount, order.Amount);
            Assert.Equal(price, order.Price);
            Assert.Equal(user, order.UserId);
        }
    }
}
