using System;
namespace TaxCalculation.Api.Models.Tax
{
    public struct GetTaxViewModelOutput
    {
        public string PostalCode { get; set; }

        public string TaxCalculationType { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
