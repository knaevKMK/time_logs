namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Configuration;

using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.HasMany(t => t.TimeLogs).WithOne(u => u.User).HasForeignKey(u => u.UserId);
    }
}