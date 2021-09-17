using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaxCalculation.Application.Tax.Queries;
using TaxCalculation.Domain.Tax.QueriesHandler;
using Xunit;

namespace TaxCalculation.Tests.UnitTests
{
    public class TaxHandelTests
    {
        private readonly ITaxCalculationQueryHandler _themeCommandService;

        public TaxHandelTests(ITaxCalculationQueryHandler themeCommandService)
        {
            _themeCommandService = new TaxCalculationQueryHandler();
        }

        public static IEnumerable<object[]> GetDataTests =>
         new List<object[]>
         {
            new object[] { "7441", 85552 },
            new object[] { "A100", 95552 },
            new object[] { "7000", 75552 },
            new object[] { "7441", 105552 },
            new object[] { "1000", 1085552 },
         };

        [Theory]
        [MemberData(nameof(GetDataTests))]
        public async Task The_Calculation_To_Inform_Annual_Income(string postalCode, decimal annualIncome)
        {
            // arrange & act & assert
            Assert.Throws<ArgumentException>(() => _themeCommandService.GetTaxCalculationQuery(postalCode, annualIncome));
        }
    }
}
