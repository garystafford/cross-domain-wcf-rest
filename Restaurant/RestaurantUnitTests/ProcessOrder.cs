using System.IO;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestaurantUnitTests
{
    [TestClass]
    public class ProcessOrder
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProcessOrder));

        private readonly Restaurant.ProcessOrder _processOrder = new Restaurant.ProcessOrder();

        [TestMethod]
        public void Test_JsonFilePath_Exists()
        {
            var jsonFilePath = Restaurant.ProcessOrder.StrJsonFilePath;
            Log.Info("Restaurant.ProcessOrder.STR_JsonFilePath: " + jsonFilePath);

            var jsonFilePathExists = Directory.Exists(jsonFilePath);

            Assert.IsTrue(jsonFilePathExists);
        }

        [TestMethod]
        public void Test_JsonFilePath_FileCountIncreasesByOne()
        {
            const string jsonFilePath = Restaurant.ProcessOrder.StrJsonFilePath;

            var jsonFilePathFileCountBefore =
                Directory.GetFiles(jsonFilePath).GetLength(0);

            const string restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";

            _processOrder.ProcessOrderJson(restaurantOrder);
            var jsonFilePathFileCountAfter =
                Directory.GetFiles(jsonFilePath).GetLength(0);

            Assert.AreEqual(jsonFilePathFileCountBefore + 1, jsonFilePathFileCountAfter);
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_EmptyOrder_ReturnsExpectedMessage()
        {
            var orderResponse = _processOrder.ProcessOrderJson(string.Empty);
            Assert.AreEqual(orderResponse.OrderMessage, "Sorry, empty order received.");
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_BadJson_ThrowsException()
        {
            var orderResponse = _processOrder.ProcessOrderJson("This is not good JSON!");
            Assert.IsTrue(orderResponse.OrderMessage.Contains("StartIndex cannot be less than zero."));
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_NewOrder_ReturnValueIsNotNull()
        {
            const string restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";
            Assert.IsNotNull(_processOrder.ProcessOrderJson(restaurantOrder));
        }

        [TestMethod]
        public void Test_ProcessOrderJSON_NewOrder_ReturnsExpectedMessage()
        {
            const string restaurantOrder = "{'restaurantOrder':[{'Quantity':'1','Id':'4'}]}";
            var orderResponse = _processOrder.ProcessOrderJson(restaurantOrder);
            Assert.AreEqual(orderResponse.OrderMessage, "Thank you for your order!");
        }
    }
}