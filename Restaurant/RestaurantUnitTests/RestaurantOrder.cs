using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using Restaurant.Models;

namespace RestaurantUnitTests
{
    [TestClass]
    public class RestaurantOrder
    {
        [TestMethod]
        public void Test_RestaurantOrder_AddOneItem_ItemCountEqualsOne()
        {
            var orderItem1 = new OrderItem(2, "Tofu", 3.49);
            var orderItem2 = new OrderItem(1, "Noodles", 5.89);
            var orderList = new List<OrderItem> {orderItem1, orderItem2};
            var restaurantOrder = new Order(orderList);
            Assert.AreEqual(restaurantOrder.OrderItems.Count, 2);
        }
    }
}