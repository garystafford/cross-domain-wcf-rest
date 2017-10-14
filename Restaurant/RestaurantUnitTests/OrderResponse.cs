using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;


namespace RestaurantUnitTests
{
    [TestClass]
    public class OrderResponse
    {
        [TestMethod]
        public void Test_OrderResponse_AddOrderViaConstructor_ItemCountEqualsOne()
        {
            var orderResponse = new Restaurant.Models.OrderResponse(
                DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture),
                ObjectId.GenerateNewId(), "Test Message");
            Assert.AreEqual(orderResponse.OrderMessage, "Test Message");
        }
    }
}
