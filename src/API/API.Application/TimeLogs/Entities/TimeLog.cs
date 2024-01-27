namespace TimeLogs.API.Application.TimeLogs.Entities;

public readonly record struct TimeLog(DateTime Date, float HoursWorked,Guid ProjectId);