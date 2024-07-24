using Auth.Application.Contracts;
using Auth.Infrastructure.Models;
using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Auth
{
    public record SignInCommand(string Username,
                                string Password) : ICommand<Result<LoginResponse>>;

    public class SignInCommandHandler : ICommandHandler<SignInCommand, Result<LoginResponse>>
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;

        public SignInCommandHandler(UserManager<AuthUser> userManager,
                                   SignInManager<AuthUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<LoginResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user is null)
            {
                return Result.Fail("User not found");
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!loginResult.Succeeded)
            {
                return Result.Fail("Invalid password");
            }

            return new LoginResponse(user.Id, user.UserName, user.Email, user.Image);
        }
    }
}
