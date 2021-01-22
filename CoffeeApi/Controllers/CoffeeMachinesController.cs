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
    public class CoffeeMachinesController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public CoffeeMachinesController(CoffeeContext context)
        {
            _context = context;
        }

        #region Return Coffee List based on filters (Size / WaterLine)

        // POST: api/CoffeeMachines
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CoffeeMachines>>> PostCoffeeMachines(CoffeeMachines coffeeMachine)
        {
            if (coffeeMachine != null)
            {                //return all coffee machines match the 2 filter parameter Size / WaterLine
                if (!string.IsNullOrEmpty(coffeeMachine.CoffeeMachineSize) && coffeeMachine.WaterLineCompatible != null)
                {
                    return await _context.CoffeeMachines.Where(R => R.CoffeeMachineSize == coffeeMachine.CoffeeMachineSize && R.WaterLineCompatible == coffeeMachine.WaterLineCompatible).ToListAsync();
                }
                //Return all machine with Size filter
                else if (string.IsNullOrEmpty(coffeeMachine.CoffeeMachineSize))
                {
                    return await _context.CoffeeMachines.Where(R => R.WaterLineCompatible == coffeeMachine.WaterLineCompatible).ToListAsync();
                }
                //Return all machine with Water filter
                else if (coffeeMachine.WaterLineCompatible == null)
                {
                    return await _context.CoffeeMachines.Where(R => R.CoffeeMachineSize == coffeeMachine.CoffeeMachineSize).ToListAsync();
                }
            }
            //Return all coffee machines incase there is no filter parameters
            return await _context.CoffeeMachines.ToListAsync();
        } 
       
        #endregion
    }
}
