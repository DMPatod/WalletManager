using DDD.Core.Handlers;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Application.Portfolios;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Enums;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Tickets
{
    public record TicketCreateCommand(string Cod,
                                      string Title,
                                      string Owner,
                                      Currency Currency,
                                      string PorfolioId) : ICommand<Result<Ticket>>;

    public class TicketCreateCommandHandler : ICommandHandler<TicketCreateCommand, Result<Ticket>>
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ITicketRepository _repository;

        public TicketCreateCommandHandler(ITicketRepository repository, IMessageHandler messageHandler)
        {
            _repository = repository;
            _messageHandler = messageHandler;
        }

        public async Task<Result<Ticket>> Handle(TicketCreateCommand request, CancellationToken cancellationToken)
        {
            var portfolioGetCommand = new PortfolioGetByIdCommand(request.PorfolioId);
            var portfolioRequest = await _messageHandler.SendAsync(portfolioGetCommand, cancellationToken);
            if (portfolioRequest.IsFailed)
            {
                return Result.Fail("");
            }

            var ticket = Ticket.Create(request.Cod, request.Title, request.Owner, request.Currency, portfolioRequest.Value);
            await _repository.CreateAsync(ticket, cancellationToken);
            return ticket;
        }
    }
}
