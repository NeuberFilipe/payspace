using System;
namespace TaxCalculation.Web.Models.Tax
{
    public struct GetTaxViewModelOutput
    {
        public string PostalCode { get; set; }

        public string TaxCalculationType { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
