using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TaxCalculation.Api.Configurations.Extensions
{
    public static class GlobalizationExtensions
    {
        public static void AddGlobalizationConfigureServices(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllers().AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new CultureInfo[] {
                        new CultureInfo("en"),
                        new CultureInfo("es"),
                        new CultureInfo("pt")
                };
                options.DefaultRequestCulture = new RequestCulture("pt");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new[] { new CustomRouteDataRequestCultureProvider() };
            });
        }

        public static IApplicationBuilder UseGlobalizationConfigure(this IApplicationBuilder app)
        {
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            return app;
        }
    }
}
