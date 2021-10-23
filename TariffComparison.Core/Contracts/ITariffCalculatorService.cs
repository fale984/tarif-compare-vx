using System.Collections.Generic;
using TariffComparison.Core.Models;

namespace TariffComparison.Core.Contracts
{
    public interface ITariffCalculatorService
    {
        IEnumerable<TariffResult> CalculateAnnualCost(decimal annualConsumption);
    }
}
