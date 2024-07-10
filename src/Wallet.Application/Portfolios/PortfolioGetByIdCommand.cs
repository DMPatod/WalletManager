using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Application.Portfolios
{
    public record PortfolioGetByIdCommand(string Id) : ICommand<Result<Portfolio>>;

    public class PortfolioGetByIdCommandHandler : ICommandHandler<PortfolioGetByIdCommand, Result<Portfolio>>
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioGetByIdCommandHandler(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Portfolio>> Handle(PortfolioGetByIdCommand request, CancellationToken cancellationToken)
        {
            var id = PortfolioId.Create(Guid.Parse(request.Id));
            var portfolio = await _repository.FindAsync(id, cancellationToken);
            return portfolio;
        }
    }
}
