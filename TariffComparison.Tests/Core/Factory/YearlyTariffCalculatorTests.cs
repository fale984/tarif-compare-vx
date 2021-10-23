using TariffComparison.Core.Factory;
using TariffComparison.Data.Models;
using Xunit;

namespace TariffComparison.Tests.Core.Factory
{
    public class YearlyTariffCalculatorTests
    {
        [Theory]
        [InlineData(800, 4000, 0.30, 3500, 800)]
        [InlineData(350, 2000, 0.25, 4500, 975)]
        [InlineData(600, 3000, 0.20, 6000, 1200)]
        [InlineData(800, 5000, 0.10, 0, 800)]
        [InlineData(800, 2000, 0.10, -3000, 800)]
        public void CalculateAnnualCostForDifferentValues(decimal baseCost, decimal threshold, decimal addedCost, decimal consumption, decimal expected)
        {
            // arrange
            var product = new TariffProduct
            {
                BaseCost = baseCost,
                Threshold = threshold,
                AddedCost = addedCost,
            };

            var calculator = new YearlyTariffCalculator();

            // act
            var annualCost = calculator.CalculateAnnualCost(product, consumption);

            // assert
            Assert.Equal(expected, annualCost);
        }
    }
}
