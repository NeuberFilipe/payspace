using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TaxCalculation.Api.Cache;
using TaxCalculation.Api.Middlewares;
using TaxCalculation.Api.Models.Tax;

namespace TaxCalculation.Api.Controllers
{
    public partial class TaxController : ApiBaseController
    {
        private IMemoryCache _cache;
        private IEnumerable<GetTaxViewModelOutput> cacheEntry;

        public TaxController(ILogger<TaxController> logger, IStringLocalizer<TaxController> localizer, IMemoryCache cache) : base(logger, localizer)
        {
            _cache = cache;
        }


        // <summary>
        /// Get Tax
        /// </summary>
        /// <returns>return resource Commite</returns>
        [SwaggerResponse(statusCode: 200, description: "Get Tax", Type = typeof(IList<GetTaxViewModelOutput>))]
        [SwaggerResponse(statusCode: 204, description: "Resource not found", Type = null)]
        [SwaggerResponse(statusCode: 401, description: "Not autorized", Type = typeof(ResultErrorViewModelOutput))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string postalCode)
        {
            cacheEntry = new List<GetTaxViewModelOutput>();
            if (!string.IsNullOrEmpty(postalCode))
            {
                cacheEntry = _cache.Get(CacheKeys.Entry) as IEnumerable<GetTaxViewModelOutput>;
                var cacheEntryFilter = cacheEntry.Where(x => x.PostalCode == postalCode);
                return Ok(cacheEntryFilter);
            }
            cacheEntry = _cache.Get(CacheKeys.Entry) as IEnumerable<GetTaxViewModelOutput>;
            return Ok(cacheEntry);
        }

        // <summary>
        /// Get Tax
        /// </summary>
        /// <returns>return resource Commite</returns>
        [SwaggerResponse(statusCode: 200, description: "Create Tax", Type = typeof(IList<GetTaxViewModelOutput>))]
        [SwaggerResponse(statusCode: 204, description: "Resource not found", Type = null)]
        [SwaggerResponse(statusCode: 401, description: "Not autorized", Type = typeof(ResultErrorViewModelOutput))]
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            List<GetTaxViewModelOutput> getTaxViewModelOutputs = MockNewTax.NewTax();

            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10000);
                return getTaxViewModelOutputs;
            });
            return Ok(cacheEntry);
        }

        

    }
}
