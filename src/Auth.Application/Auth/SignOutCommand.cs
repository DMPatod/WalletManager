using Auth.Infrastructure.Models;
using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Auth
{
    public record SignOutCommand() : ICommand<Result>;

    public class SignOutCommandHandler : ICommandHandler<SignOutCommand, Result>
    {
        private readonly SignInManager<AuthUser> _signInManager;

        public SignOutCommandHandler(SignInManager<AuthUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Result> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Result.Ok();
        }
    }
}
