namespace TimeLogs.API.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Projects;
using Application.TimeLogs;
using Application.Users;
using Databases.TimeLogsDatabase;

public static class DepenedencyInjection
{
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        _ = services.AddDbContext<TimeLogsDbContext>(options => options.UseInMemoryDatabase($"TimeLogs-{Guid.NewGuid()}"), ServiceLifetime.Singleton);

        _ = services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        _ = services.AddSingleton<EntityFrameworkTimeLogsRepository>();

        _ = services.AddSingleton<IUsersRepository>(p => p.GetRequiredService<EntityFrameworkTimeLogsRepository>());
        _ = services.AddSingleton<IProjectsRepository>(x => x.GetRequiredService<EntityFrameworkTimeLogsRepository>());
        _ = services.AddSingleton<ITimeLogsRepository>(x => x.GetRequiredService<EntityFrameworkTimeLogsRepository>());

        _ = services.AddSingleton(TimeProvider.System);

        return services;
    }
}