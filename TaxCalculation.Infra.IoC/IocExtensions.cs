using System;
using Microsoft.Extensions.DependencyInjection;
using TaxCalculation.Application.Tax.Queries;
using TaxCalculation.Domain.Tax.QueriesHandler;

namespace TaxCalculation.Infra.IoC
{
    public static class IocExtensions
    {
        public static void AddIocConfigureServicesQuery(this IServiceCollection services)
        {
            services.AddScoped<ITaxCalculationQueryHandler, TaxCalculationQueryHandler>();
           
        }
    }
}
