using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Services.Products
{
    public interface IProductAppService
    {
        public Task<bool> UpdateProductStock(string merchantProductNo, int newAmount);
    }
}
