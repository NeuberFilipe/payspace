using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using TaxCalculation.Api.Cache;
using TaxCalculation.Api.Middlewares;
using TaxCalculation.Api.Models.Tax;
using TaxCalculation.Domain.Tax.QueriesHandler;

namespace TaxCalculation.Api.Controllers
{
	public partial class TaxController
	{
        // <summary>
        /// Get Tax
        /// </summary>
        /// <returns>return resource Commite</returns>
        [SwaggerResponse(statusCode: 200, description: "Get Tax Calculation")]
        [SwaggerResponse(statusCode: 204, description: "Resource not found", Type = null)]
        [SwaggerResponse(statusCode: 401, description: "Not autorized", Type = typeof(ResultErrorViewModelOutput))]
        [HttpGet]
        [Route("calculation")]
        public async Task<IActionResult> GetCalculation(
         [FromQuery] string postalCode,
         [FromQuery] decimal annualIncome,
         [FromServices] ITaxCalculationQueryHandler _taxCalculationQueryHandler) => Ok(_taxCalculationQueryHandler.GetTaxCalculationQuery(postalCode, annualIncome));
    }
}
