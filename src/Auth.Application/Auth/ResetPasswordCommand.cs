using Auth.Infrastructure.Models;
using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Auth
{
    public record ResetPasswordCommand(string Email, string Token, string Password) : ICommand<Result>;

    public class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand, Result>
    {
        private readonly UserManager<AuthUser> _userManager;

        public ResetPasswordCommandHandler(UserManager<AuthUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Result.Fail("User not found");
            }

            var reset = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
            if (!reset.Succeeded)
            {
                var errors = reset.Errors.Select(e => e.Description);
                return Result.Fail(errors);
            }

            return Result.Ok();
        }
    }
}
