using DDD.Core.Handlers;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Application.Tickets
{
    public record TicketFindByIdCommand(string Id) : ICommand<Result<Ticket>>;

    public class TicketFindByIdCommandHandler : ICommandHandler<TicketFindByIdCommand, Result<Ticket>>
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ITicketRepository _repository;

        public TicketFindByIdCommandHandler(ITicketRepository repository, IMessageHandler messageHandler)
        {
            _repository = repository;
            _messageHandler = messageHandler;
        }

        public async Task<Result<Ticket>> Handle(TicketFindByIdCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.FindAsync(new TicketId(request.Id), cancellationToken);
            if (ticket is null)
            {
                return Result.Fail("");
            }

            return ticket;
        }
    }
}
