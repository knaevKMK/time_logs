namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Models;

using System.ComponentModel.DataAnnotations.Schema;

internal record TimeLog : Entity
{
    public DateTime Date { get; init; }
    public float HoursWorked { get; init; }

    [ForeignKey("FK_UserId")] public Guid UserId { get; set; }

    public User User { get; init; }

    [ForeignKey("FK_Project_Id")] public Guid ProjectId { get; init; }

    public Project Project { get; init; } = default!;
}