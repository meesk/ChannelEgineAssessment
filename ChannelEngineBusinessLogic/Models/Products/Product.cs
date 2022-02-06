using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineBusinessLogic.Models.Products
{
    public class Content
    {
        public bool IsActive { get; set; }
        public string MerchantProductNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Ean { get; set; }
        public string ManufacturerProductNumber { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int MSRP { get; set; }
        public int PurchasePrice { get; set; }
        public string VatRateType { get; set; }
        public int ShippingCost { get; set; }
        public string ShippingTime { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string ExtraImageUrl1 { get; set; }
        public string ExtraImageUrl2 { get; set; }
        public string ExtraImageUrl3 { get; set; }
        public string ExtraImageUrl4 { get; set; }
        public string ExtraImageUrl5 { get; set; }
        public string ExtraImageUrl6 { get; set; }
        public string ExtraImageUrl7 { get; set; }
        public string ExtraImageUrl8 { get; set; }
        public string ExtraImageUrl9 { get; set; }
        public string CategoryTrail { get; set; }
    }

    public class Product
    {
        public Content Content { get; set; }
        public int StatusCode { get; set; }
        public int LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }
    }

}
