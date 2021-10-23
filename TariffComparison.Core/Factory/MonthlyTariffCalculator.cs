using TariffComparison.Core.Contracts;
using TariffComparison.Data.Models;

namespace TariffComparison.Core.Factory
{
    public class MonthlyTariffCalculator : ITariffCalculatorMethod
    {
        public decimal CalculateAnnualColst(TariffProduct product, decimal consumption)
        {
            decimal annualCost = product.BaseCost * 12;

            if (consumption > 0)
            {
                annualCost += consumption * product.AddedCost;
            }

            return annualCost;
        }
    }
}
