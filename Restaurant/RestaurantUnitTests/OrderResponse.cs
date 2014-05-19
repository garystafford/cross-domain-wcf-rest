using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantUnitTests
{
    [TestClass]
    public class OrderResponse
    {
        [TestMethod]
        public void Test_OrderResponse_AddOrderViaConstructor_ItemCountEqualsOne()
        {
            var orderResponse = new Restaurant.OrderResponse(
                DateTime.Now.ToLocalTime().ToString(),
                Guid.NewGuid(), 1, "Test Message");
            Assert.AreEqual(orderResponse.ItemCount, 1);
        }
    }
}
