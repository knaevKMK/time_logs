using MediatR;
using TimeLogs.API.Application.Users.Entities;

namespace TimeLogs.API.Application.Users.Queries.GetUsers;

public class GetUsersHandler: IRequestHandler<GetUsersQuery, List<User>>
{
    private readonly IUsersRepository _repository;
    
    public GetUsersHandler(IUsersRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetUsers(cancellationToken);
    }
}