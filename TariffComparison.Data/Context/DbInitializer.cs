using System.Linq;
using TariffComparison.Data.Models;

namespace TariffComparison.Data.Context
{
    public static class DbInitializer
    {
        /// <summary>
        /// Creates initial products if required
        /// </summary>
        /// <param name="context">Db context</param>
        public static void Initialize(ComparisonDataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            context.Products.Add(new TariffProduct
            {
                Name = "Basic Electricity Tariff",
                Model = TariffModel.Monthly,
                BaseCost = 5,
                AddedCost = 0.22m,
            });

            context.Products.Add(new TariffProduct
            {
                Name = "Packaged Tariff",
                Model = TariffModel.Yearly,
                BaseCost = 800,
                Threshold = 4000,
                AddedCost = 0.30m,
            });

            context.SaveChanges();
        }
    }
}
