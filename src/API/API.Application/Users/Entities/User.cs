using TimeLogs.API.Application.TimeLogs.Entities;

namespace TimeLogs.API.Application.Users.Entities;

public readonly record struct User(Guid Id, string Firstname, string Lastname, string Email, ICollection<TimeLog> TimeLogs);