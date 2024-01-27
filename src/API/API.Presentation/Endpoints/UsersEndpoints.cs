using System.Net.Mime;

namespace TimeLogs.API.Presentation.Endpoints;

using MediatR;
using Entities =  Application.Users.Entities;
using Queries = Application.Users.Queries;

public static class UsersEndpoints
{
    public static WebApplication MapUsersEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/users")
            .WithTags("users")
            .WithOpenApi();

        _ = root.MapGet("/", GetUsers)
            .Produces<List<Entities.User>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Lookup all Users")
            .WithDescription("\n    GET /Users");


        return app;
    }
    
    public static async Task<IResult> GetUsers(IMediator mediator)
    {
        try
        {
            return Results.Ok(await mediator.Send(new Queries.GetUsers.GetUsersQuery()));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}

