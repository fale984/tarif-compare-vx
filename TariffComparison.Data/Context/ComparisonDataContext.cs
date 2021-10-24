using Microsoft.EntityFrameworkCore;
using TariffComparison.Data.Models;

namespace TariffComparison.Data.Context
{
    public class ComparisonDataContext : DbContext
    {
        public DbSet<TariffProduct> Products { get; set; }

        public ComparisonDataContext(DbContextOptions<ComparisonDataContext> options) : base(options)
        {
        }
    }
}
