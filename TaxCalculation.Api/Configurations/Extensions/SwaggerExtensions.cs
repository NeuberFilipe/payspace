using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Linq;
using System.Reflection;
using TaxCalculation.Api.Filters;

namespace TaxCalculation.Api.Configurations.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerConfigureServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Api Tax Calculation",
                    Version = Assembly.GetExecutingAssembly().GetInformationalVersion(),
                    Description = $"Api Tax Calculation",
                });
                c.OperationFilter<PermissionsFilter>();
            });
        }

        public static IApplicationBuilder UseSwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(0);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Committee Management V1");
                c.RoutePrefix = string.Empty;
            });

            return app;
        }

        public class PermissionsFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var filterDescriptors = context.ApiDescription.ActionDescriptor.FilterDescriptors;

                var customAuthorizationFilter = (ApiAuthorizationFilter)filterDescriptors
                                                .Select(filterInfo => filterInfo.Filter)
                                                .FirstOrDefault(filter => filter is ApiAuthorizationFilter);

                if (customAuthorizationFilter != null)
                {
                    operation.Description = $"{operation.Description} Permissions : {customAuthorizationFilter.PermissionNames}";
                }
            }
        }
    }
}
