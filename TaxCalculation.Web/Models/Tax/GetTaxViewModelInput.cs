using System;
namespace TaxCalculation.Web.Models.Tax
{
    public class GetTaxViewModelInput
    {
        public string PostalCode { get; set; }
        public string AnnualIncome { get; set; }
    }
}
