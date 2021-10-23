using TariffComparison.Core.Contracts;
using TariffComparison.Data.Models;

namespace TariffComparison.Core.Factory
{
    public class YearlyTariffCalculator : ITariffCalculatorMethod
    {
        /// <summary>
        /// Calculates the cost as annual base + difference in consumption * kWh cost
        /// </summary>
        /// <param name="product">Product information</param>
        /// <param name="consumption">Consumption</param>
        /// <returns>Annual cost</returns>
        public decimal CalculateAnnualCost(TariffProduct product, decimal consumption)
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
