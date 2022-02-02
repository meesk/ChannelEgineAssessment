using ChannelEngineBusinessLogic.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Models
{
    public class Order
    {
        public List<Line> Lines { get; set; }
    }
}
