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
            String jsonFilePath = Restaurant.ProcessOrder.STR_JsonFilePath;
            
            int jsonFilePathFileCountBefore =
                Directory.GetFiles(jsonFilePath).GetLength(0);

            String restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";

            processOrder.ProcessOrderJSON(restaurantOrder);
            int jsonFilePathFileCountAfter =
                Directory.GetFiles(jsonFilePath).GetLength(0);

            Assert.AreEqual(jsonFilePathFileCountBefore + 1, jsonFilePathFileCountAfter);
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_EmptyOrder__HasExpectedValues()
        {
            Restaurant.OrderResponse orderResponse = processOrder.ProcessOrderJSON(String.Empty);
            Assert.AreEqual(orderResponse.OrderMessage, "Sorry, empty order received.");
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_BadJson__ThrowsException()
        {
            Restaurant.OrderResponse orderResponse = processOrder.ProcessOrderJSON("This is not good JSON!");
            Assert.IsTrue(orderResponse.OrderMessage.Contains("StartIndex cannot be less than zero."));
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_ReturnValue_IsNotNull()
        {
            String restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";
            Assert.IsNotNull(processOrder.ProcessOrderJSON(restaurantOrder));
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_NewOrder_HasExpectedValues()
        {
            String restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";
            Restaurant.OrderResponse orderResponse = processOrder.ProcessOrderJSON(restaurantOrder);
            Assert.AreEqual(orderResponse.OrderMessage, "Thank you for your order!");
        }
    }
}
