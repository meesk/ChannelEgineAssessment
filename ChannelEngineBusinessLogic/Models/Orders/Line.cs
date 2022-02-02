using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Models.Orders
{
    public class Linea
    {
        public string GTIN { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
