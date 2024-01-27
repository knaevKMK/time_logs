namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Extensions;

using Bogus;
using Models;

internal static class TimeLogsDbContextExtensions
{
    public static TimeLogsDbContext AddData(this TimeLogsDbContext context)
    {
        var users = new Faker<User>()
            .RuleFor(u => u.FirstName,
                f => f.PickRandom("John", "Gringo", "Mark", "Lisa", "Maria", "Sonya", "Philip", "Jose", "Lorenzo",
                    "George", "Justin"))
            .RuleFor(u => u.LastName,
                f => f.PickRandom("Johnson", "Lamas", "Jackson", "Brown", "Mason", "Rodriguez", "Roberts", "Thomas",
                    "Rose", "McDonalds"))
            .RuleFor(u => u.Email,
                (f, u) => f.Internet.Email(u.FirstName, u.LastName,
                    f.PickRandom("hotmail.com", "gmail.com", "live.com")))
            .Generate(100);

        context.Users.AddRange(users);

        var projects = new List<Project>
        {
            new Project { Name = "My own" },
            new Project { Name = "Free Time" },
            new Project { Name = "Work" }
        };

        context.AddRange(projects);

        var timeLogFaker = new Faker<TimeLog>()
            .RuleFor(t => t.UserId, f => f.PickRandom(users).Id)
            .RuleFor(t => t.ProjectId, f => f.PickRandom(projects).Id)
            .RuleFor(t => t.Date, f => f.Date.Recent())
            .RuleFor(t => t.HoursWorked, f => f.Random.Double(0.25, 8.00));

        var timeLogs = timeLogFaker.Generate(100);

        context.AddRange(timeLogs);

        _ = context.SaveChanges();

        return context;
    }
}