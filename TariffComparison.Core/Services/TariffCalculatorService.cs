using System.Collections.Generic;
using System.Linq;
using TariffComparison.Core.Contracts;
using TariffComparison.Core.Models;
using TariffComparison.Data.Models;

namespace TariffComparison.Core.Services
{
    /// <inheritdoc />
    public class TariffCalculatorService : ITariffCalculatorService
    {
        private readonly ITariffCalculatorFactory calculatorFactory;

        public TariffCalculatorService(ITariffCalculatorFactory factory)
        {
            calculatorFactory = factory;
        }

        /// <inheritdoc />
        public IEnumerable<TariffResult> CalculateAnnualCost(IEnumerable<TariffProduct> products, decimal annualConsumption)
        {
            var results = products.Select(p => CalculateAnnualCost(p, annualConsumption));

            return results;
        }

        /// <summary>
        /// Creates a tariff result with the respective annual cost
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="annualConsumption">Annual consumption</param>
        /// <returns>Annual cost</returns>
        public TariffResult CalculateAnnualCost(TariffProduct product, decimal annualConsumption)
        {
            var result = new TariffResult
            {
                Id = product.Id,
                Name = product.Name,
                AnnualCost = 0,
            };

            var calculator = calculatorFactory.GetCalculator(product.Model);
            if (calculator != null)
            {
                result.AnnualCost = calculator.CalculateAnnualCost(product, annualConsumption);
            }

            return result;
        }
    }
}
