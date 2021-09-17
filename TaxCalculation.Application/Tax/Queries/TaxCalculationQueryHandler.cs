using System;
using System.Threading.Tasks;
using TaxCalculation.Domain.Tax.QueriesHandler;

namespace TaxCalculation.Application.Tax.Queries
{
    public class TaxCalculationQueryHandler : ITaxCalculationQueryHandler
    {

        public double GetTaxCalculationQuery(string postalCode, decimal annualIncome)
        {
            var i = postalCode switch
            {
                "7441" => TaxCalculationPattern.TaxCalculationProgressivePatter(annualIncome),
                "A100" => TaxCalculationPattern.TaxCalculationFlatValuePatter(annualIncome),
                "7000" => TaxCalculationPattern.TaxCalculationFlatRatePatter(annualIncome),
                "1000" => TaxCalculationPattern.TaxCalculationProgressivePatter(annualIncome),
                _ => throw new NotImplementedException("Postal Code Notfound"),
            };
            return i;
        }

    }
}
