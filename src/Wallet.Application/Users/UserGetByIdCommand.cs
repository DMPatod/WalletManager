using DDD.Core.Handlers;
using DDD.Core.Messages;
using FluentResults;
using Wallet.Domain.Users;
using Wallet.Domain.Users.Repositories;
using Wallet.Domain.Users.ValueObjects;

namespace Wallet.Application.Users
{
    public record UserGetByIdCommand(string Id) : ICommand<Result<User>>;

    public class UserGetByIdCommandHandler : ICommandHandler<UserGetByIdCommand, Result<User>>
    {
        private readonly IUserRepository _repository;

        public UserGetByIdCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<User>> Handle(UserGetByIdCommand request, CancellationToken cancellationToken)
        {
            var id = UserId.Create(Guid.Parse(request.Id));
            var user = await _repository.FindAsync(id, cancellationToken);
            if (user is null)
            {
                return Result.Fail("User not Found");
            }

            return user;
        }
    }
}
