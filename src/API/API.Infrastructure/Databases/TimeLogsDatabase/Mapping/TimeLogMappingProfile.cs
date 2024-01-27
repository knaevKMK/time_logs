namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Mapping;

using AutoMapper;
using Application = Application.TimeLogs.Entities;
using Infrastructure = Models;

public class TimeLogMappingProfile: Profile
{
    public TimeLogMappingProfile()
    {
        _ = this.CreateMap<Infrastructure.TimeLog, Application.TimeLog>()
            .ReverseMap();
    }
}