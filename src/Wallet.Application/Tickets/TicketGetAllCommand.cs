using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Tickets
{
    public record TicketGetAllCommand() : ICommand<Result<IList<Ticket>>>;

    public class TicketGetAllCommandHandler : ICommandHandler<TicketGetAllCommand, Result<IList<Ticket>>>
    {
        private readonly ITicketRepository _repository;

        public TicketGetAllCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IList<Ticket>>> Handle(TicketGetAllCommand request, CancellationToken cancellationToken)
        {
            var list = await _repository.FindAsync(cancellationToken);
            return list.ToList();
        }
    }
}
