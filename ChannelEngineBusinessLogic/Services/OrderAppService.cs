using ChannelEngineBusinessLogic.Models;
using ChannelEngineBusinessLogic.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services
{
    public class OrderAppService : IOrderAppService
    {
        public List<Order> GetOrders()
        {
            var orders = new List<Order>();
            var list = new List<Line>();
            list.Add(new Line() { GTIN = "1234", Name = "Test", Quantity = 4 });
            orders.Add(new Order { Lines = list });
            return orders;
        }
    }
}
