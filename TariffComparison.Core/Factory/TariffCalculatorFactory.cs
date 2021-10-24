using System.Collections.Generic;
using TariffComparison.Core.Contracts;
using TariffComparison.Data.Models;

namespace TariffComparison.Core.Factory
{
    /// <inheritdoc />
    public class TariffCalculatorFactory : ITariffCalculatorFactory
    {
        private readonly Dictionary<TariffModel, ITariffCalculatorMethod> calculators;

        public TariffCalculatorFactory()
        {
            calculators = new Dictionary<TariffModel, ITariffCalculatorMethod>
            {
                { TariffModel.Monthly, new MonthlyTariffCalculator() },
                { TariffModel.Yearly, new YearlyTariffCalculator() }
            };
        }

        /// <inheritdoc />
        public ITariffCalculatorMethod GetCalculator(TariffModel model)
        {
            if (calculators.ContainsKey(model))
            {
                return calculators[model];
            }
            else
            {
                return null;
            }
        }
    }
}
