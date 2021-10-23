using TariffComparison.Data.Models;

namespace TariffComparison.Core.Contracts
{
    public interface ITariffCalculatorMethod
    {
        decimal CalculateAnnualCost(TariffProduct product, decimal consumption);
    }
}
