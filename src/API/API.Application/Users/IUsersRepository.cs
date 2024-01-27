namespace TimeLogs.API.Application.Users;

using Entities;

public interface IUsersRepository
{
    Task<List<User>> GetUsers(CancellationToken cancellationToken);
}