﻿using DDD.Core.Handlers;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Application.Tickets;
using Wallet.Application.Users;
using Wallet.Domain.Orders;
using Wallet.Domain.Orders.Enums;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Orders
{
    public record OrderCreateCommand(string TicketId,
                                     string Date,
                                     OperationType Type,
                                     bool DayTrade,
                                     bool Completed,
                                     double Amount,
                                     double Price,
                                     string UserId) : ICommand<Result<Order>>;

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
            var getTicketCommand = new TicketGetByIdCommand(request.TicketId);
            var ticketRequest = await _messageHandler.SendAsync(getTicketCommand, cancellationToken);
            if (ticketRequest.IsFailed)
            {
                return Result.Fail("Ticket not found.");
            }

            if (!DateTime.TryParse(request.Date, out var dateTime))
            {
                return Result.Fail("Invalid date format.");
            }

            var getUserCommand = new UserGetByIdCommand(request.UserId);
            var userRequest = await _messageHandler.SendAsync(getUserCommand, cancellationToken);
            if (userRequest.IsFailed)
            {
                return Result.Fail("User not found.");
            }

            var order = Order.Create(ticketRequest.Value,
                                     dateTime,
                                     request.Type,
                                     request.DayTrade,
                                     request.Completed,
                                     request.Amount,
                                     request.Price,
                                     userRequest.Value.Id);
            await _repository.CreateAsync(order, cancellationToken);
            return order;
        }
    }
}
