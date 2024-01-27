namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Models;

internal record Project : Entity
{
    public string Name { get; init; }

    public ICollection<TimeLog> TimeLogs { get; init; }
}