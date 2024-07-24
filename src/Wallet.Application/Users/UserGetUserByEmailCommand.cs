using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Users;
using Wallet.Domain.Users.Repositories;

namespace Wallet.Application.Users
{
    public record UserGetUserByEmailCommand(string Email) : ICommand<Result<User>>;

    public class UserGetUserByEmailCommandHandler : ICommandHandler<UserGetUserByEmailCommand, Result<User>>
    {
        private readonly IUserRepository _repository;

        public UserGetUserByEmailCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<User>> Handle(UserGetUserByEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindByEmailAsync(request.Email, cancellationToken);
            if (user is null)
            {

                return Result.Fail("User not found");
            }

            return user;
        }
    }
}
