using System;
namespace TaxCalculation.Application.Tax
{
    public class TaxCalculationPattern
    {
        public static double TaxCalculationProgressivePatter(decimal annualIncome)
        {
            switch (annualIncome)
            {
                case 0:
                case <= 8350:
                    return CalculationPercente(annualIncome, 10);
                case 8351:
                case <= 33950:
                    return CalculationPercente(annualIncome, 15);
                case 33951:
                case <= 82250:
                    return CalculationPercente(annualIncome, 25);
                case 82251:
                case <= 171550:
                    return CalculationPercente(annualIncome, 28);
                case 171551:
                case <= 372950:
                    return CalculationPercente(annualIncome, 33);
                case > 372951:
                    return CalculationPercente(annualIncome, 35);
                default:
                    return 0;
            }
        }

        private static double CalculationPercente(decimal annualIncome, double percet)
        {
            return percet / 100 * (double)annualIncome;
        }


        public static double TaxCalculationFlatValuePatter(decimal annualIncome)
        {
            switch (annualIncome)
            {
                case 0:
                case < 200000:
                    return CalculationPercente(annualIncome, 5);
                default:
                    return 10000;
            }
        }

        public static double TaxCalculationFlatRatePatter(decimal annualIncome)
        {
            return CalculationPercente(annualIncome, 17.5);
        }
    }
}
