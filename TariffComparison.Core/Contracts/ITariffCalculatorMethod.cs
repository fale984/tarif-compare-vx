using TariffComparison.Data.Models;

namespace TariffComparison.Core.Contracts
{
    /// <summary>
    /// Allows calculating annual cost based on consumption
    /// </summary>
    public interface ITariffCalculatorMethod
    {
        decimal CalculateAnnualCost(TariffProduct product, decimal consumption);
    }
}
