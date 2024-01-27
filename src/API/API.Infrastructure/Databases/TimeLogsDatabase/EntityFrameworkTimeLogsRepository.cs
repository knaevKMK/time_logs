using Microsoft.EntityFrameworkCore;

namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase;

using AutoMapper;
using Extensions;
using Application.Users;
using Application.Projects;
using Application.TimeLogs;
using ApplicationUser = Application.Users.Entities.User;

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

    #region Users

    public virtual async Task<List<ApplicationUser>> GetUsers(CancellationToken cancellationToken)
    {
        var users = await this.context.Users.Include(t => t.TimeLogs).AsNoTracking().ToListAsync(cancellationToken);

        return this.mapper.Map<List<ApplicationUser>>(users);
    }

    #endregion
}