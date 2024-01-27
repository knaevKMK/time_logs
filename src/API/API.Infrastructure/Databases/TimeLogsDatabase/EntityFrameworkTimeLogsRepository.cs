using AutoMapper;
using TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Extensions;

namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase;

using Application.Users;
using Application.Projects;
using Application.TimeLogs;

internal class EntityFrameworkTimeLogsRepository : IUsersRepository, IProjectsRepository, ITimeLogsRepository
{
    private readonly TimeLogsDbContext context;
    private readonly TimeProvider timeProvider;
    private readonly IMapper mapper;
    
    public EntityFrameworkTimeLogsRepository(TimeLogsDbContext  context, TimeProvider timeProvider, IMapper mapper)
    {
        this.context = context;
        this.timeProvider = timeProvider;
        this.mapper = mapper;

        if (this.context != null)
        {
            _ = this.context.Database.EnsureDeleted();
            _ = this.context.Database.EnsureCreated();
            _ = this.context.AddData();
        }
    }
}