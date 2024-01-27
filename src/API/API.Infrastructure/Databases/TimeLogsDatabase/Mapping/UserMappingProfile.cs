namespace TimeLogs.API.Infrastructure.Databases.TimeLogsDatabase.Mapping;

using AutoMapper;
using Application = Application.Users.Entities;
using Infrastructure = Models;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        _ = this.CreateMap<Infrastructure.User, Application.User>()
            .ReverseMap();
    }
}