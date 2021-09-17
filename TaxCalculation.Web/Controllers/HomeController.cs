using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TaxCalculation.Domain.Tax.QueriesHandler;
using TaxCalculation.Web.Cache;
using TaxCalculation.Web.Configurations;
using TaxCalculation.Web.Models;
using TaxCalculation.Web.Models.Tax;

namespace TaxCalculation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _cache;
        private IEnumerable<GetTaxViewModelOutput> cacheEntry;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            MockNewTax.NewTax();
            _cache = cache;
        }

        public IActionResult Index()
        {
            List<GetTaxViewModelOutput> getTaxViewModelOutputs = MockNewTax.NewTax();
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10000);
                return getTaxViewModelOutputs;
            });
        
            ViewData["GetTaxViewModelOutput"] = cacheEntry;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public ActionResult JqAJAX(GetTaxViewModelInput getTaxInput, [FromServices] ITaxCalculationQueryHandler _taxCalculationQueryHandler)
        {
            if (!string.IsNullOrEmpty(getTaxInput.PostalCode) && getTaxInput.AnnualIncome != null)
                {
                    return Ok(_taxCalculationQueryHandler.GetTaxCalculationQuery(getTaxInput.PostalCode, decimal.Parse(getTaxInput.AnnualIncome)));
                }
                return Ok("Postal Code and Annual Income is required");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
