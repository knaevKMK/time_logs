namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Models;

internal sealed class TimeLogsDbContext : DbContext
{
    public TimeLogsDbContext(DbContextOptions<TimeLogsDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TimeLog> TimeLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}