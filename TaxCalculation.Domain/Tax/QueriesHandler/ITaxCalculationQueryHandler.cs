using System;
namespace TaxCalculation.Domain.Tax.QueriesHandler
{
    public interface ITaxCalculationQueryHandler
    {
        double GetTaxCalculationQuery(string postalCode, decimal annualIncome);
    }
}
