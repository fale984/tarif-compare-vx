using TariffComparison.Data.Models;

namespace TariffComparison.Core.Contracts
{
    /// <summary>
    /// Allows selecting different calculators according to the tariff model type
    /// </summary>
    public interface ITariffCalculatorFactory
    {
        /// <summary>
        /// Returns calculator for the specified tariff model
        /// </summary>
        /// <param name="model">Tariff model</param>
        /// <returns>Cost calculator</returns>
        ITariffCalculatorMethod GetCalculator(TariffModel model);
    }
}
