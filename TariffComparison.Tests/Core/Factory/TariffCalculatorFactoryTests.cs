using TariffComparison.Core.Factory;
using TariffComparison.Data.Models;
using Xunit;

namespace TariffComparison.Tests.Core.Factory
{
    public class TariffCalculatorFactoryTests
    {
        [Fact]
        public void GetCalculatorShouldReturnForMonthly()
        {
            // arrange
            var factory = new TariffCalculatorFactory();

            // act
            var calculator = factory.GetCalculator(TariffModel.Monthly);

            // assert
            Assert.NotNull(calculator);
            Assert.IsType<MonthlyTariffCalculator>(calculator);
        }

        [Fact]
        public void GetCalculatorShouldReturnForYearly()
        {
            // arrange
            var factory = new TariffCalculatorFactory();

            // act
            var calculator = factory.GetCalculator(TariffModel.Yearly);

            // assert
            Assert.NotNull(calculator);
            Assert.IsType<YearlyTariffCalculator>(calculator);
        }

        [Fact]
        public void GetCalculatorShouldReturnNullForInvalid()
        {
            // arrange
            var factory = new TariffCalculatorFactory();

            // act
            var calculator = factory.GetCalculator((TariffModel)10);

            // assert
            Assert.Null(calculator);
        }
    }
}
