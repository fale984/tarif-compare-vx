using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Core.Contracts;
using TariffComparison.Core.Models;
using TariffComparison.Data.Context;
using TariffComparison.Data.Models;

namespace TariffComparison.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ComparisonDataContext dataContext;
        private readonly ITariffCalculatorService calculatorService;

        public ProductsController(ComparisonDataContext context, ITariffCalculatorService calculator)
        {
            dataContext = context;
            calculatorService = calculator;
        }

        // GET api/products
        [HttpGet]
        public async Task<IEnumerable<TariffProduct>> GetAsync()
        {
            var products = await dataContext.Products.ToListAsync();

            return products;
        }

        // GET api/products/2
        [HttpGet("{id}")]
        public async Task<ActionResult<TariffProduct>> GetByIdAsync(int id)
        {
            var product = await dataContext.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        // GET api/products/estimate/4500
        [HttpGet("estimate/{consumption}")]
        public async Task<ActionResult<IEnumerable<TariffResult>>> EstimateAnnualCost(decimal consumption)
        {
            var products = await dataContext.Products.ToListAsync();

            var estimationResults = calculatorService.CalculateAnnualCost(products, consumption);

            return estimationResults.OrderBy(r => r.AnnualCost).ToList();
        }

        // POST api/products
        [HttpPost]
        public async Task<ActionResult<TariffProduct>> SaveAsync([FromBody] TariffProduct productToSave)
        {
            if (productToSave is null)
            {
                return BadRequest();
            }

            dataContext.Products.Add(productToSave);
            await dataContext.SaveChangesAsync();

            return Ok(productToSave);
        }
    }
}
