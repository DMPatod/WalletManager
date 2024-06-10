using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Portfolios
{
    public record PortfolioCreateCommand(string Title) : ICommand<Result<Portfolio>>;

    public class PortfolioCreateCommandHandler : ICommandHandler<PortfolioCreateCommand, Result<Portfolio>>
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioCreateCommandHandler(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Portfolio>> Handle(PortfolioCreateCommand request, CancellationToken cancellationToken)
        {
            var portfolio = Portfolio.Create(request.Title);
            await _repository.CreateAsync(portfolio, cancellationToken);
            return portfolio;
        }
    }
}
