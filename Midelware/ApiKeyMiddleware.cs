using Microsoft.AspNetCore.Mvc.Filters;
using SkiService.Controllers;

namespace SkiService.Midelware
{
    /// <summary>
    /// Diese Midelware wird nicht verwendet / Wird in einem Weiteren Schtritt gebraucht
    /// </summary>
    [AttributeUsage(validOn: AttributeTargets.Method)]
    public class ApiKeyMiddleware :Attribute
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";
        private readonly ILogger<RegistrationController> _logger;

        /// <summary>
        /// Konstruktor für instanziierung von Delegate
        /// </summary>
        /// <param name="next"></param>
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Mothode um APIKey Überprüfen
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided. (Using ApiKeyMiddleware) ");

                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client. (Using ApiKeyMiddleware)");
                return;
            }
            await _next(context);
        }
    }
}

