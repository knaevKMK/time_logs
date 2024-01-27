namespace TimeLogs.API.Application.Users.Queries.GetUsers;

using MediatR;
using Entities;

public class GetUsersQuery: IRequest<List<User>>
{
}