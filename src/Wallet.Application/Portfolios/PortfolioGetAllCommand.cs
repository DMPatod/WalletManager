using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Portfolios
{
    public record PortfolioGetAllCommand() : ICommand<Result<IList<Portfolio>>>;

    public class PortfolioGetAllCommandHandler : ICommandHandler<PortfolioGetAllCommand, Result<IList<Portfolio>>>
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioGetAllCommandHandler(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IList<Portfolio>>> Handle(PortfolioGetAllCommand request, CancellationToken cancellationToken)
        {
            var list = await _repository.FindAsync(cancellationToken);
            return list.ToList();
        }
    }
}
