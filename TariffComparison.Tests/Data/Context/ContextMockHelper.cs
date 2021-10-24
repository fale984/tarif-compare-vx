using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TariffComparison.Data.Context;

namespace TariffComparison.Tests.Data.Context
{
    internal static class ContextMockHelper
    {
        /// <summary>
        /// Creates in memory database for testing
        /// </summary>
        /// <param name="dbName">Database name, will exist during all test execution</param>
        /// <returns>Db context</returns>
        public static ComparisonDataContext CreateContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ComparisonDataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new ComparisonDataContext(options);
        }
    }
}
