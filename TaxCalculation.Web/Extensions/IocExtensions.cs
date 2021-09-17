using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculation.Infra.IoC;

namespace TaxCalculation.Web.Extensions
{
    public static class IocExtensions
    {
        public static void AddIocConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIocConfigureServicesQuery();
        }
    }
}
