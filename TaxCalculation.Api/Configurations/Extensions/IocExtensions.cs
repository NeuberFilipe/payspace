using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculation.Infra.IoC;

namespace TaxCalculation.Api.Configurations.Extensions
{
    public static class IocExtensions
    {
        public static void AddIocConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCorsConfigureServices();
            services.AddGlobalizationConfigureServices();
            services.AddApplicationInsightsTelemetry();
            services.AddSwaggerConfigureServices();
            services.AddIocConfigureServicesQuery();
        }
    }
}
