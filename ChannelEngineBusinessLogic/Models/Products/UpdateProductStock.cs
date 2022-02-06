using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Models.Products
{
    public class UpdateProductStock
    {
        public string Op { get; set; }
        public string Path { get; set; }
        public int Value { get; set; }
    }
}
