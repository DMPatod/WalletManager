using Wallet.Domain.Orders.Enums;

namespace WalletManager.API.Contracts.Orders
{
    public record OrderCreateRequest(string TicketId,
                                     string Date,
                                     OperationType Type,
                                     double Amount,
                                     double Price);
}
