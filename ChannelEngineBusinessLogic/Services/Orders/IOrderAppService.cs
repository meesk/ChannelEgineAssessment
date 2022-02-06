using ChannelEngineBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services.Orders
{
    public interface IOrderAppService
    {
        public Task<IEnumerable<Line>> GetTopFiveOrders();
    }
}
