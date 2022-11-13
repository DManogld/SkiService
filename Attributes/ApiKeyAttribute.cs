using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SkiService.Controllers;

namespace ApiKeyCustomAttributes.Attributes
{
    /// <summary>
    /// Atribut Class für API Key
    /// Hier werden die Targets bestummen.
    /// </summary>
    [AttributeUsage(validOn: AttributeTargets.Method | AttributeTargets.Class)]

    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private readonly ILogger<ApiKeyAttribute> _logger;
        private const string APIKEYNAME = "ApiKey";

        /// <summary>
        /// Methode um die API Key zu überprüfen
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns>Authoriation</returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
            };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }
            await next();
        }
    }
}
