using ChannelEngineBusinessLogic.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ChannelEngineTests
{
    public class BusinessLogic_Tests
    {
        private IEnumerable<Line> dummyInput;

        [Test]
        public void TopOrders_Count_ShouldBeFour()
        {
            //Arrange
            dummyInput = new List<Line>()
            {
                new Line() { Quantity = 1, MerchantProductNo = "001201-S", Gtin = "8719351029609"},
                new Line() { Quantity = 2, MerchantProductNo = "001201-M", Gtin = "8719351029609"},
                new Line() { Quantity = 3, MerchantProductNo = "001201-XL", Gtin = "8719351029609"},
                new Line() { Quantity = 3, MerchantProductNo = "001201-L", Gtin = "8719351029609"},

            };

            //Act
            var count = dummyInput.Count();

            //Assert
            Assert.AreEqual(4, count);
        }

        [Test]
        public void TopOrders_OrderQuantity_ShouldBeDescending()
        {
            //Arrange
            dummyInput = new List<Line>()
            {
                new Line() { Quantity = 1, MerchantProductNo = "001201-S", Gtin = "8719351029609"},
                new Line() { Quantity = 2, MerchantProductNo = "001201-M", Gtin = "8719351029609"},
                new Line() { Quantity = 3, MerchantProductNo = "001201-XL", Gtin = "8719351029609"},
                new Line() { Quantity = 3, MerchantProductNo = "001201-L", Gtin = "8719351029609"},

            };

            //Act
            var descending = dummyInput.OrderByDescending(x => x.Quantity);

            //Assert
            var result = isDescendingOrder(descending);
            Assert.AreEqual(true, result);
        }
        private bool isDescendingOrder(IOrderedEnumerable<Line> lines)
        {
            var a = lines.ToList();
            for (int i = 0; i < a.Count() - 1; i++)
            {
                if (a[i].Quantity < a[i + 1].Quantity)
                    return false;
            }
            return true;
        }

    }
}