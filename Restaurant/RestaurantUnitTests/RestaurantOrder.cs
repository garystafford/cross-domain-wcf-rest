using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantUnitTests
{
    [TestClass]
    public class RestaurantOrder
    {
        [TestMethod]
        public void Test_RestaurantOrder_AddOneItem_ItemCountEqualsOne()
        {
            var orderItem1 = new OrderItem("Tofu", 3.49, 2);
            var orderItem2 = new OrderItem("Noodles", 5.89, 1);
            var orderList = new List<OrderItem> {orderItem1, orderItem2};
            var restaurantOrder = new Restaurant.RestaurantOrder {new Order(orderList)};
            Assert.AreEqual(restaurantOrder.Count, 2);
        }
    }
}