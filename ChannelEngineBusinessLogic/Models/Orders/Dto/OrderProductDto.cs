﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Models.Orders.Dto
{
    public class OrderProductDto
    {
        public string ProductName { get; set; }
        public string GTIN { get; set; }
        public int Quantity { get; set; }
    }
}
