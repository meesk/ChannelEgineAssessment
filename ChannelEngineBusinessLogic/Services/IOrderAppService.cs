using ChannelEngineBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services
{
    public interface IOrderAppService
    {
        public List<Order> GetOrders();
    }
}
