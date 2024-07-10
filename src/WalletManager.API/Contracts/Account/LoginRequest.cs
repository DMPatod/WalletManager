namespace WalletManager.API.Contracts.Account
{
    public record LoginRequest(string Username,
                               string Password,
                               bool RememberMe,
                               string ReturnUrl,
                               string Button);
}
