using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantTests
{
    [TestClass]
    public class ProcessOrderTests
    {
        [TestMethod]
        public void ProcessOrderJsonTestAsync()
        {
            var processOrderMongo = new ProcessOrder();
            const string order = "{\"restaurantOrder\":[{\"Quantity\":\"1\",\"Description\":\"Cheeseburger\",\"Price\":\"3.99\"}," +
                                 "{\"Quantity\":\"5\",\"Description\":\"Hot Dog\",\"Price\":\"2.49\"}]}&callback=OrderResponse&_=1507906662155";
            processOrderMongo.ProcessOrderJson(order);

            //Assert.Fail();
        }
    }
}