using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TaxCalculation.Api.Configurations.Extensions
{
    public static class CorsExtensions
    {
        public static void AddCorsConfigureServices(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("default", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public static IApplicationBuilder UseCorsConfigure(this IApplicationBuilder app)
        {
            app.UseCors("default");
            return app;
        }
    }
}
