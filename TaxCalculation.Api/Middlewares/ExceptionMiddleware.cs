using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TaxCalculation.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.TargetSite.ReflectedType.FullName, GetErrorInnerException(ex));

                await HandleExceptionAsync(httpContext, new Exception(GetErrorInnerException(ex)), HttpStatusCode.InternalServerError);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ResultErrorViewModelOutput(exception.Message)));
        }

        public static string GetErrorInnerException(Exception exception)
        {
            if (exception.InnerException != null)
            {
                return GetErrorInnerException(exception.InnerException);
            }
            else
            {
                return exception.Message;
            }
        }
    }
}
