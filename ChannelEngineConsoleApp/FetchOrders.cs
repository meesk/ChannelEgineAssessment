using ChannelEngineBusinessLogic.Models;
using ChannelEngineBusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineConsoleApp
{
    public class FetchOrders
    {
        private readonly IOrderAppService appService;

        public FetchOrders(IOrderAppService _appService)
        {
            appService = _appService;
        }


        public List<Order> GetOrders()
        {
            return appService.GetOrders();
        }
    }
}
