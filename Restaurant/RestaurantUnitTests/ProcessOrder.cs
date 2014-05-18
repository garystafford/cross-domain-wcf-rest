using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using System.IO;

namespace RestaurantUnitTests
{
    [TestClass]
    public class ProcessOrder
    {
        private Restaurant.ProcessOrder processOrder = new Restaurant.ProcessOrder();

        [TestMethod]
        public void Test_JsonFilePath_Exists()
        {
            bool jsonFilePathExists = Directory.Exists(Restaurant.ProcessOrder.STR_JsonFilePath);
            Assert.IsTrue(jsonFilePathExists);
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_ReturnValue_IsNotNull()
        {
            String restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";
            Assert.IsNotNull(processOrder.ProcessOrderJSON(restaurantOrder));
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_ItemCount_IsOne()
        {
            String restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";
            OrderResponse orderResponse = processOrder.ProcessOrderJSON(restaurantOrder);
            Assert.AreEqual(orderResponse.ItemCount, 1);
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_OrderMessage_NotError()
        {
            String restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";
            OrderResponse orderResponse = processOrder.ProcessOrderJSON(restaurantOrder);
            Assert.AreEqual(orderResponse.OrderMessage, "Thank you for your order!");
        }
    }
}
