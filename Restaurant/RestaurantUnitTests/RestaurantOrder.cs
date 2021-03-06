﻿using System.Collections.ObjectModel;
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
            var orderItem = new OrderItem(1, 2);
            var orderList = new Collection<OrderItem> {orderItem};
            var restaurantOrder = new Restaurant.RestaurantOrder(orderList);
            Assert.AreEqual(restaurantOrder.Count, 1);
        }
    }
}