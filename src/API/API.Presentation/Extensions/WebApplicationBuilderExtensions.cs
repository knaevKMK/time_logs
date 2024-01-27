namespace TimeLogs.API.Presentation.Extensions;

using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using Infrastructure;
using Serilog;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        #region Logging

        _ = builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
        {
            var assembly = Assembly.GetEntryAssembly();

            _ = loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration)
                .Enrich.WithProperty(
                    "Assembly Version",
                    assembly?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version)
                .Enrich.WithProperty(
                    "Assembly Informational Version",
                    assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion);
        });

        #endregion Logging

        #region Serialisation

        _ = builder.Services.Configure<JsonOptions>(opt =>
        {
            opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            opt.SerializerOptions.PropertyNameCaseInsensitive = true;
            opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        });

        #endregion Serialisation

        #region Swagger

        var ti = CultureInfo.CurrentCulture.TextInfo;

        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"TimeLogs API - {ti.ToTitleCase(builder.Environment.EnvironmentName)}",
                    Description = "An example to share an implementation of Minimal API in .NET 7.",
                    Contact = new OpenApiContact
                    {
                        Name = "Time Logs API",
                        Email = "vladimirpet91@gmail.com",
                        Url = new Uri("https://github.com/vladimirpetukhov/time_logs")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Time Logs API - License - MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    },
                    TermsOfService = new Uri("https://vladimirpetukhov.github.io/resume/")
                });

            options.DocInclusionPredicate((name, api) => true);
        });

        #endregion Swagger

        #region Validation

        _ = builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        #endregion Validation

        #region Project Dependencies

        _ = builder.Services.AddInfrastructure();
       // _ = builder.Services.AddApplication();

        #endregion Project Dependencies

        return builder;
    }
}