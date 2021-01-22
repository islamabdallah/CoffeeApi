using System;
using System.Collections.Generic;

namespace CoffeeApi.Models
{
    public partial class CoffeePods
    {
        public int Id { get; set; }
        public string CoffeePodCode { get; set; }
        public string CoffeePodSize { get; set; }
        public string CoffeeFlavor { get; set; }
        public string PackSize { get; set; }
    }
}
