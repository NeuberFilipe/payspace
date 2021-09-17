using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TaxCalculation.Api.Middlewares;

namespace TaxCalculation.Api.Controllers
{
    [Route("api/{culture}/v1/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly IStringLocalizer _localizer;

        public ApiBaseController(ILogger logger, IStringLocalizer localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object error)
        {
            return base.BadRequest(new ResultErrorViewModelOutput(error.ToString()));
        }

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object value)
        {
            return base.NotFound(new ResultErrorViewModelOutput(value.ToString()));
        }
    }
}
