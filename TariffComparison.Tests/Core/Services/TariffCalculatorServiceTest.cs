using Moq;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.Core.Contracts;
using TariffComparison.Core.Services;
using TariffComparison.Data.Models;
using Xunit;

namespace TariffComparison.Tests.Core.Services
{
    public class TariffCalculatorServiceTest
    {
        private Mock<ITariffCalculatorFactory> factoryMock;
        private Mock<ITariffCalculatorMethod> calculatorMock;

        public TariffCalculatorServiceTest()
        {
            factoryMock = new Mock<ITariffCalculatorFactory>();
            calculatorMock = new Mock<ITariffCalculatorMethod>();
        }

        [Fact]
        public void CalculateAnnualCostCalculatesForSingleProduct()
        {
            // arrange
            var consumption = 3500;
            var product = new TariffProduct
            {
                Id = 8,
                Name = "My product",
                Model = TariffModel.Monthly
            };

            factoryMock
                .Setup(m => m.GetCalculator(TariffModel.Monthly))
                .Returns(calculatorMock.Object);

            calculatorMock
                .Setup(m => m.CalculateAnnualCost(product, consumption))
                .Returns(1200.15m);

            var service = new TariffCalculatorService(factoryMock.Object);

            // act
            var result = service.CalculateAnnualCost(product, consumption);

            // assert
            Assert.NotNull(result);
            Assert.Equal(8, result.Id);
            Assert.Equal("My product", result.Name);
            Assert.Equal(1200.15m, result.AnnualCost);
        }

        [Fact]
        public void CalculateAnnualCostHandlesNullCalculator()
        {
            // arrange
            var consumption = 3500;
            var product = new TariffProduct
            {
                Id = 0,
                Name = "Undefined product",
                Model = TariffModel.Undefined
            };

            factoryMock
                .Setup(m => m.GetCalculator(It.IsAny<TariffModel>()))
                .Returns<ITariffCalculatorMethod>(null);

            var service = new TariffCalculatorService(factoryMock.Object);

            // act
            var result = service.CalculateAnnualCost(product, consumption);

            // assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Id);
            Assert.Equal("Undefined product", result.Name);
            Assert.Equal(0, result.AnnualCost);
        }

        [Fact]
        public void CalculateAnnualCostCalculatesForMultipleProduct()
        {
            // arrange
            var consumption = 3500;
            int itemCount = 5;
            List<TariffProduct> products = new List<TariffProduct>();
            for (int i = 1; i <= itemCount; i++)
            {
                var product = new TariffProduct
                {
                    Id = i,
                    Name = "My product " + i,
                    Model = TariffModel.Monthly
                };
                products.Add(product);
            }

            factoryMock
                .Setup(m => m.GetCalculator(It.IsAny<TariffModel>()))
                .Returns(calculatorMock.Object);

            calculatorMock
                .Setup(m => m.CalculateAnnualCost(It.IsAny<TariffProduct>(), consumption))
                .Returns(1200.15m);

            var service = new TariffCalculatorService(factoryMock.Object);

            // act
            var result = service.CalculateAnnualCost(products, consumption).ToList();

            // assert
            Assert.NotNull(result);
            Assert.Equal(itemCount, result.Count);
            factoryMock.Verify(m => m.GetCalculator(It.IsAny<TariffModel>()), Times.Exactly(itemCount));
            calculatorMock.Verify(m => m.CalculateAnnualCost(It.IsAny<TariffProduct>(), consumption), Times.Exactly(itemCount));
        }
    }
}
