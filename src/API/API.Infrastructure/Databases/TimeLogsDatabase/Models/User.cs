namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Models;

internal record User : Entity
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }

    public ICollection<TimeLog> TimeLogs { get; init; }
}