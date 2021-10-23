using TariffComparison.Core.Factory;
using TariffComparison.Data.Models;
using Xunit;

namespace TariffComparison.Tests.Core.Factory
{
    public class MonthlyTariffCalculatorTests
    {
        [Theory]
        [InlineData(5, 0.22, 3500, 830)]
        [InlineData(6, 0.25, 4500, 1197)]
        [InlineData(7, 0.10, 6000, 684)]
        [InlineData(5, 0.22, 0, 60)]
        [InlineData(5, 0.22, -100, 60)]
        public void CalculateAnnualCostForDifferentValues(decimal baseCost, decimal addedCost, decimal consumption, decimal expected)
        {
            // arrange
            var product = new TariffProduct
            {
                BaseCost = baseCost,
                AddedCost = addedCost
            };

            var calculator = new MonthlyTariffCalculator();

            // act
            var annualCost = calculator.CalculateAnnualCost(product, consumption);

            // assert
            Assert.Equal(expected, annualCost);
        }
    }
}
