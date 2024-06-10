using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Orders
{
    public record OrderGetAllCommand : ICommand<Result<IList<Order>>>;

    public class OrderGetAllCommandHandler : ICommandHandler<OrderGetAllCommand, Result<IList<Order>>>
    {
        private readonly IOrderRepository _repository;

        public OrderGetAllCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IList<Order>>> Handle(OrderGetAllCommand request, CancellationToken cancellationToken)
        {
            var list = await _repository.FindAsync(cancellationToken);
            return list.ToList();
        }
    }
}
