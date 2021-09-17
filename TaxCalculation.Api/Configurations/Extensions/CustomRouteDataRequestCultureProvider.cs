using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace TaxCalculation.Api.Configurations.Extensions
{
    public class CustomRouteDataRequestCultureProvider : RequestCultureProvider
    {
        public int IndexOfCulture = 2;
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            string culture = "pt";
            if (httpContext.Request.Path.Value.Contains("api") &&
               !httpContext.Request.Path.Value.Contains("healthchecks"))
            {
                culture = httpContext.Request.Path.Value.Split('/')[IndexOfCulture]?.ToString();
            }

            var providerResultCulture = new ProviderCultureResult(culture);

            return Task.FromResult(providerResultCulture);
        }
    }
}
