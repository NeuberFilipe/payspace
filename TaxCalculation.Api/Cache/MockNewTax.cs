using System;
using System.Collections.Generic;
using TaxCalculation.Api.Models.Tax;

namespace TaxCalculation.Api.Cache
{
    public static class MockNewTax
    {
        public static List<GetTaxViewModelOutput> NewTax()
        {
            List<GetTaxViewModelOutput> getTaxViewModelOutputs = new List<GetTaxViewModelOutput>();

            getTaxViewModelOutputs.Add(new GetTaxViewModelOutput()
            {
                PostalCode = "7441",
                TaxCalculationType = "Progressive",
                CreateDate = DateTime.Now
            });
            getTaxViewModelOutputs.Add(new GetTaxViewModelOutput()
            {
                PostalCode = "A100",
                TaxCalculationType = "Flat Value",
                CreateDate = DateTime.Now
            });
            getTaxViewModelOutputs.Add(new GetTaxViewModelOutput()
            {
                PostalCode = "7000",
                TaxCalculationType = "Flat rate",
                CreateDate = DateTime.Now
            });
            getTaxViewModelOutputs.Add(new GetTaxViewModelOutput()
            {
                PostalCode = "1000",
                TaxCalculationType = "Progressive",
                CreateDate = DateTime.Now
            });
            return getTaxViewModelOutputs;
        }
    }
}
