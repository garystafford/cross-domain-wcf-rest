using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantTests
{
    [TestClass()]
    public class ProcessOrderMongoTests
    {
        [TestMethod()]
        public void ProcessOrderJsonTest()
        {
            var processOrderMongo = new ProcessOrderMongo();
            const string order = "{\"restaurantOrder\":[{\"Qnt.\":\"1\",\"Description\":\"Cheeseburger\",\"Price\":\"3.99\"}," +
                                 "{\"Qnt.\":\"5\",\"Description\":\"Hot Dog\",\"Price\":\"2.49\"}]}&callback=OrderResponse&_=1507906662155";
            processOrderMongo.ProcessOrderJson(order);
            //Assert.Fail();
        }
    }
}