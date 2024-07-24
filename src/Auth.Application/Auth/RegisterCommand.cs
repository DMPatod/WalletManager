using Auth.Application.Contracts;
using Auth.Infrastructure.Models;
using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Auth
{
    public record RegisterCommand(string Username,
                                  string Email,
                                  string Password) : ICommand<Result<RegisterResponse>>;

    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<RegisterResponse>>
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;

        public RegisterCommandHandler(UserManager<AuthUser> userManager,
                                   SignInManager<AuthUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(new AuthUser
            {
                UserName = request.Username,
                Email = request.Email,
            }, request.Password);
            if (!result.Succeeded)
            {
                return Result.Fail("Failed to create user");
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            return new RegisterResponse(user.Id,
                                        user.Email);
        }
    }
}
