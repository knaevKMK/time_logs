namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

internal sealed class ProjectConfiguration: IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        _ = builder.HasMany(t => t.TimeLogs).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId);
    }
}