using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffComparison.Core.Models;
using TariffComparison.Data.Models;

namespace TariffComparison.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TariffProduct>>> GetAsync()
        {
            List<TariffProduct> prods = new List<TariffProduct>();
            prods.Add(new TariffProduct());

            return prods;
        }

        // GET api/product
        [HttpGet("estimate/{consumption}")]
        public async Task<ActionResult<IEnumerable<TariffResult>>> EstimateAnnualCost(decimal consumption)
        {
            List<TariffResult> prods = new List<TariffResult>();
            prods.Add(new TariffResult() { Id = 1, Name = "Prod 1", AnnualCost = consumption * 12 });
            prods.Add(new TariffResult() { Id = 2, Name = "Prod 2", AnnualCost = consumption * 6 });

            return prods;
        }
    }
}
