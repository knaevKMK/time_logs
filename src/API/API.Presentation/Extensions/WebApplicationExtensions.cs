using System.Globalization;
using Serilog;

namespace TimeLogs.API.Presentation.Extensions;

public static  class WebApplicationExtensions
{
     public static WebApplication ConfigureApplication(this WebApplication app)
 {
     #region Logging

     _ = app.UseSerilogRequestLogging();

     #endregion Logging

     #region Security

     _ = app.UseHsts();

     #endregion Security

     #region API Configuration

     _ = app.UseHttpsRedirection();

     #endregion API Configuration

     #region Swagger

     var ti = CultureInfo.CurrentCulture.TextInfo;

     _ = app.UseSwagger();
     _ = app.UseSwaggerUI(c =>
         c.SwaggerEndpoint(
             "/swagger/v1/swagger.json",
             $"Time Logs - {ti.ToTitleCase(app.Environment.EnvironmentName)} - V1"));

     #endregion Swagger

     #region MinimalApi

     // _ = app.MapVersionEndpoints();
     // _ = app.MapAuthorEndpoints();
     // _ = app.MapMovieEndpoints();
     // _ = app.MapReviewEndpoints();

     #endregion MinimalApi

     return app;
 }
}