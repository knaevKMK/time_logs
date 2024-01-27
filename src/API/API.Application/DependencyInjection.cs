using Microsoft.Extensions.Configuration;

namespace TimeLogs.API.Application;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication( this IServiceCollection services,
        IConfiguration configuration)
    {
        _ = services.AddMediatR((config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())));

        return services;
    }
}