using TariffComparison.Core.Contracts;
using TariffComparison.Data.Models;

namespace TariffComparison.Core.Factory
{
    public class YearlyTariffCalculator : ITariffCalculatorMethod
    {
        public decimal CalculateAnnualColst(TariffProduct product, decimal consumption)
        {
            decimal annualCost = product.BaseCost;

            if (consumption > product.Threshold)
            {
                annualCost += (consumption - product.Threshold) * product.AddedCost;
            }

            return annualCost;
        }
    }
}
