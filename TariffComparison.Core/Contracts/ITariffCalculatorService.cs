using System.Collections.Generic;
using TariffComparison.Core.Models;
using TariffComparison.Data.Models;

namespace TariffComparison.Core.Contracts
{
    /// <summary>
    /// Allows calculating the annual consumption for different products
    /// </summary>
    public interface ITariffCalculatorService
    {
        /// <summary>
        /// Calculates annual cost for the products
        /// </summary>
        /// <param name="products">Available products</param>
        /// <param name="annualConsumption">Annual consumption</param>
        /// <returns>List of annual results</returns>
        IEnumerable<TariffResult> CalculateAnnualCost(IEnumerable<TariffProduct> products, decimal annualConsumption);
    }
}
