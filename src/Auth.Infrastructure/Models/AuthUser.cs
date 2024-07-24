using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Models
{
    public class AuthUser : IdentityUser
    {
        public string? Image { get; set; }
    }
}
