using Wallet.Domain.Orders.Enums;

namespace WalletManager.API.Contracts.Tickets
{
    public record TicketCreateRequest(string Cod, string Title, string Owner, Currency Currency, string PortfolioId);
}
