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
            String jsonFilePath = Restaurant.ProcessOrder.STR_JsonFilePath;
            Console.WriteLine("Restaurant.ProcessOrder.STR_JsonFilePath: " + jsonFilePath);

            bool jsonFilePathExists = Directory.Exists(jsonFilePath);

            Assert.IsTrue(jsonFilePathExists);
        }

        [TestMethod]
        public void Test_JsonFilePath_FileCountIncreasesByOne()
        {
            int jsonFilePathFileCountBefore =
                Directory.GetFiles(Restaurant.ProcessOrder.STR_JsonFilePath).GetLength(0);
            Console.WriteLine("jsonFilePathFileCountBefore: " + jsonFilePathFileCountBefore);

            String restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";

            processOrder.ProcessOrderJSON(restaurantOrder);
            int jsonFilePathFileCountAfter =
                Directory.GetFiles(Restaurant.ProcessOrder.STR_JsonFilePath).GetLength(0);
            Console.WriteLine("jsonFilePathFileCountAfter: " + jsonFilePathFileCountAfter);

            Assert.AreEqual(jsonFilePathFileCountBefore + 1, jsonFilePathFileCountAfter);
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
