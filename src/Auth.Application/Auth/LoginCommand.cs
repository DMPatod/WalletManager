using Auth.Application.Contracts;
using Auth.Infrastructure.Models;
using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Auth
{
    public record LoginCommand(LoginRequest Request) : ICommand<Result<LoginResponse>>;

    public class LoginCommandHandler : ICommandHandler<LoginCommand, Result<LoginResponse>>
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginCommandHandler(UserManager<AuthUser> userManager,
                                   SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Request.Username);
            if (user is null)
            {
                return Result.Fail("User not found");
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, request.Request.Password, false, false);
            if (!loginResult.Succeeded)
            {
                return Result.Fail("Invalid password");
            }

            return new LoginResponse(user.Id, user.UserName, user.Email, user.Image);
        }
    }
}
