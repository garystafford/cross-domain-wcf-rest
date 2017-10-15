using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestaurantUnitTests
{
    [TestClass]
    public class OrderResponse
    {
        [TestMethod]
        public void Test_OrderResponse_AddOrderViaConstructor_ItemCountEqualsOne()
        {
            var orderResponse = new Restaurant.Models.OrderResponse
            {
                OrderMessage = "Test Message"
            };
            Assert.AreEqual(orderResponse.OrderMessage, "Test Message");
        }
    }
}
