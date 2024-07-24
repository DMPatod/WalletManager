using Auth.Infrastructure.Models;
using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Auth
{
    public record GeneratePasswordResetTokenCommand(string Email) : ICommand<Result<string>>;

    public class GeneratePasswordResetTokenCommandHandler : ICommandHandler<GeneratePasswordResetTokenCommand, Result<string>>
    {
        private readonly UserManager<AuthUser> _userManager;

        public GeneratePasswordResetTokenCommandHandler(UserManager<AuthUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<string>> Handle(GeneratePasswordResetTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Result.Fail("User not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return token;
        }
    }
}
