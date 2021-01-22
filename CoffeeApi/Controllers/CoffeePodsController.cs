using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeApi.Models;

namespace CoffeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeePodsController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public CoffeePodsController(CoffeeContext context)
        {
            _context = context;
        }

        #region Return Coffee pods List based on filters (Size / flavor / packs)
        // POST: api/CoffeePods
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CoffeePods>>> PostCoffeePods(CoffeePods coffeepods)
        {
            if(coffeepods!=null)
            {
                #region All Filters
                if (!string.IsNullOrEmpty(coffeepods.CoffeePodSize) && !string.IsNullOrEmpty(coffeepods.CoffeeFlavor) && !string.IsNullOrEmpty(coffeepods.PackSize))
                {
                    return await _context.CoffeePods.Where(R => R.CoffeePodSize == coffeepods.CoffeePodSize && R.CoffeeFlavor == coffeepods.CoffeeFlavor && R.PackSize == coffeepods.PackSize).ToListAsync();
                }
                #endregion

                #region 2 Filters
                if (!string.IsNullOrEmpty(coffeepods.CoffeePodSize) && !string.IsNullOrEmpty(coffeepods.CoffeeFlavor))
                {
                    return await _context.CoffeePods.Where(R => R.CoffeePodSize == coffeepods.CoffeePodSize && R.CoffeeFlavor == coffeepods.CoffeeFlavor).ToListAsync();
                }
                if (!string.IsNullOrEmpty(coffeepods.CoffeePodSize) && !string.IsNullOrEmpty(coffeepods.PackSize))
                {
                    return await _context.CoffeePods.Where(R => R.CoffeePodSize == coffeepods.CoffeePodSize && R.PackSize == coffeepods.PackSize).ToListAsync();
                }
                if (!string.IsNullOrEmpty(coffeepods.CoffeeFlavor) && !string.IsNullOrEmpty(coffeepods.PackSize))
                {
                    return await _context.CoffeePods.Where(R => R.CoffeeFlavor == coffeepods.CoffeeFlavor && R.PackSize == coffeepods.PackSize).ToListAsync();
                }
                #endregion

                #region 1 Filters
                if (!string.IsNullOrEmpty(coffeepods.CoffeePodSize) )
                {
                    return await _context.CoffeePods.Where(R => R.CoffeePodSize == coffeepods.CoffeePodSize).ToListAsync();
                }
                if (!string.IsNullOrEmpty(coffeepods.PackSize))
                {
                    return await _context.CoffeePods.Where(R =>R.PackSize == coffeepods.PackSize).ToListAsync();
                }
                if (!string.IsNullOrEmpty(coffeepods.CoffeeFlavor))
                {
                    return await _context.CoffeePods.Where(R => R.CoffeeFlavor == coffeepods.CoffeeFlavor).ToListAsync();
                }
                #endregion
            }
            return await _context.CoffeePods.ToListAsync();
        }

        #endregion
    }
}
