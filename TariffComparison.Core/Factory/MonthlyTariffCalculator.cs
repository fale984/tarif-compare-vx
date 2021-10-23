using TariffComparison.Core.Contracts;
using TariffComparison.Data.Models;

namespace TariffComparison.Core.Factory
{
    public class MonthlyTariffCalculator : ITariffCalculatorMethod
    {
        /// <summary>
        /// Calculates the cost as monthly base * 12 + consumption * kWh cost
        /// </summary>
        /// <param name="product">Product information</param>
        /// <param name="consumption">Consumption</param>
        /// <returns>Annual cost</returns>
        public decimal CalculateAnnualCost(TariffProduct product, decimal consumption)
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
