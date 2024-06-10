using DDD.Core.Handlers;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Application.Tickets;
using Wallet.Domain.Orders;
using Wallet.Domain.Orders.Enums;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Orders
{
    public record OrderCreateCommand(string TicketId,
                                     string Date,
                                     OperationType Type,
                                     double Amount,
                                     double Price) : ICommand<Result<Order>>;

    public class OrderCreateCommandHandler : ICommandHandler<OrderCreateCommand, Result<Order>>
    {
        private readonly IMessageHandler _messageHandler;

        private readonly IOrderRepository _repository;

        public OrderCreateCommandHandler(IMessageHandler messageHandler, IOrderRepository repository)
        {
            _messageHandler = messageHandler;
            _repository = repository;
        }

        public async Task<Result<Order>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var getTicketCommand = new TicketFindByIdCommand(request.TicketId);
            var ticketRequest = await _messageHandler.SendAsync(getTicketCommand, cancellationToken);
            if (ticketRequest.IsFailed)
            {
                return Result.Fail("");
            }

            if (DateTime.TryParse(request.Date, out var dateTime))
            {
                return Result.Fail("");
            }

            var order = Order.Create(ticketRequest.Value, dateTime, request.Type, request.Amount, request.Price);
            await _repository.CreateAsync(order, cancellationToken);
            return order;
        }
    }
}
