namespace WalletManager.API.Contracts.Account
{
    public record LogoutRequest(string PostLogoutRedirectUri,
                                string ClientName,
                                string SingOutIframeUrl,
                                bool AutomaticRedirectAfterSignOut);
}
