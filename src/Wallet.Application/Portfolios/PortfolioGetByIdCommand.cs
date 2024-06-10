using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.Repositories;

namespace Wallet.Application.Portfolios
{
    public record PortfolioGetByIdCommand(string Title) : ICommand<Result<Portfolio>>;

    public class PortfolioGetByIdCommandHandler : ICommandHandler<PortfolioGetByIdCommand, Result<Portfolio>>
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioGetByIdCommandHandler(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Portfolio>> Handle(PortfolioGetByIdCommand request, CancellationToken cancellationToken)
        {
            var portfolio = Portfolio.Create(request.Title);
            await _repository.CreateAsync(portfolio, cancellationToken);
            return portfolio;
        }
    }
}
