namespace WalletManager.API.Contracts.Account
{
    public record RegisterRequest(string Username,
                                  string Email,
                                  string Password);
}
