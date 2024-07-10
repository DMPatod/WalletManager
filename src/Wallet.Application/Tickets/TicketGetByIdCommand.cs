using DDD.Core.Handlers;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Application.Tickets
{
    public record TicketGetByIdCommand(string Id) : ICommand<Result<Ticket>>;

    public class TicketGetByIdCommandHandler : ICommandHandler<TicketGetByIdCommand, Result<Ticket>>
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ITicketRepository _repository;

        public TicketGetByIdCommandHandler(ITicketRepository repository, IMessageHandler messageHandler)
        {
            _repository = repository;
            _messageHandler = messageHandler;
        }

        public async Task<Result<Ticket>> Handle(TicketGetByIdCommand request, CancellationToken cancellationToken)
        {
            var id = TicketId.Create(Guid.Parse(request.Id));
            var ticket = await _repository.FindAsync(id, cancellationToken);
            if (ticket is null)
            {
                return Result.Fail("Ticket not Found");
            }

            return ticket;
        }
    }
}
