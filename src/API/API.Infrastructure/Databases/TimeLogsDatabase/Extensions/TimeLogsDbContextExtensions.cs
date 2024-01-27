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

        var _random = new Random();
        foreach (var user in users)
        {
            var numberOfEntries = _random.Next(1, 21);

            for (int i = 0; i < numberOfEntries; i++)
            {
                var project = projects[_random.Next(projects.Count)];

                // Ensure that hours worked per entry do not exceed 8 working hours per day
                var maxHoursPerDay = 8.00f;
                var remainingHours = maxHoursPerDay;

                // Generate random hours within the limit
                var hoursWorked = (float)(_random.NextDouble() * (Math.Min(remainingHours, 8.00 - 0.25)) + 0.25);

                // Update remaining hours
                remainingHours -= hoursWorked;

                context.TimeLogs.Add(new TimeLog
                    { UserId = user.Id, ProjectId = project.Id, Date = DateTime.Now, HoursWorked = hoursWorked });
            }
        }

        _ = context.SaveChanges();

        return context;
    }
}