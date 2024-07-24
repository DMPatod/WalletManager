namespace WalletManager.API.Contracts.Account
{
    public record SignInRequest(string Username,
                               string Password,
                               bool RememberMe);
}
