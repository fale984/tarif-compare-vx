using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Data.Context;
using TariffComparison.Data.Models;
using Xunit;

namespace TariffComparison.Tests.Data.Context
{
    public class DbInitializerTests
    {
        [Fact]
        public async Task InitializeCreatesProductsAsync()
        {
            // arrange
            var dbName = "TariffTestingMockDb_Required";
            List<TariffProduct> products;

            // act
            using (var context = ContextMockHelper.CreateContext(dbName))
            {
                DbInitializer.Initialize(context);
            }

            // assert
            using (var context = ContextMockHelper.CreateContext(dbName))
            {
                products = await context
                    .Products
                    .OrderBy(p => p.Id)
                    .ToListAsync();
            }

            Assert.NotNull(products);
            Assert.Equal(2, products.Count);
            Assert.Equal(1, products[0].Id);
            Assert.Equal(TariffModel.Monthly, products[0].Model);
            Assert.Equal(TariffModel.Yearly, products[1].Model);
        }

        [Fact]
        public async Task InitializeDoesNotCreateProductsIfNotRequiredAsync()
        {
            // arrange
            var dbName = "TariffTestingMockDb_NotRequired";
            List<TariffProduct> products;

            using (var context = ContextMockHelper.CreateContext(dbName))
            {
                context.Products.Add(new TariffProduct());
                await context.SaveChangesAsync();
            }

            // act
            using (var context = ContextMockHelper.CreateContext(dbName))
            {
                DbInitializer.Initialize(context);
            }

            // assert
            using (var context = ContextMockHelper.CreateContext(dbName))
            {
                products = await context
                    .Products
                    .OrderBy(p => p.Id)
                    .ToListAsync();
            }

            Assert.NotNull(products);
            Assert.Single(products);
            Assert.Equal(1, products[0].Id);
            Assert.Equal(TariffModel.Undefined, products[0].Model);
        }
    }
}
