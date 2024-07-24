namespace WalletManager.API.Contracts.Account
{
    public record PasswordResetRequest(string Email, string Token, string Password);
}
