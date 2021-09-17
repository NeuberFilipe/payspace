using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace TaxCalculation.Api.Filters
{
    public class ApiAuthorizationFilter : ActionFilterAttribute
    {
        private string[] _permissions;

        public ApiAuthorizationFilter(string[] permissions)
        {
            _permissions = permissions;
        }

        public string PermissionNames => string.Join(",", _permissions);

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
            }

            var configuration = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            var disabledAuthorized = configuration.GetValue<bool?>("DisabledAuthorized");
            if (!disabledAuthorized.HasValue || disabledAuthorized.Value)
            {
                await base.OnActionExecutionAsync(context, next);
            }
            context.Result = new ForbidResult();
        }
    }
}
