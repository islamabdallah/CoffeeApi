using System;
using System.Collections.Generic;

namespace CoffeeApi.Models
{
    public partial class CoffeeMachines
    {
        public int Id { get; set; }
        public string CoffeeMachineCode { get; set; }
        public string CoffeeMachineSize { get; set; }
        public string CoffeeMachineModel { get; set; }
        public bool? WaterLineCompatible { get; set; }
    }
}
