using TariffComparison.Data.Models;

namespace TariffComparison.Core.Contracts
{
    public interface ITariffCalculatorMethod
    {
        decimal CalculateAnnualColst(TariffProduct product, decimal consumption);
    }
}
