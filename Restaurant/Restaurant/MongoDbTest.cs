using System;
using System.Collections.Generic;
using log4net;
using MongoDB.Driver;
using Restaurant.Models;

namespace Restaurant
{
    public class MongoDbTest
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProcessOrder));

        public void TestMongo()
        {
            var database = MongoAuthConnectionFactory.MongoDatabase("restaurant");

            var collectionMenuItems = database.GetCollection<MenuItem>("menuItems");
            collectionMenuItems.DeleteMany(x => x.Description != "");
            collectionMenuItems.InsertMany(new Menu());
            collectionMenuItems.InsertOne(new MenuItem("Tofu", 3.49));

            var collectionOrders = database.GetCollection<Order>("orders");
            var orderItems = new List<OrderItem>
            {
                new OrderItem(2, "Tea", 2.99),
                new OrderItem(1, "Fudge Bar", 1.29)
            };

            var order = new Order(orderItems);
            collectionOrders.InsertOne(order);


            //var list = collectionMenuItems
            //    .Find(x => x.Description == "Tofu");

            //foreach (var menuItem in list)
            //    Console.WriteLine(menuItem);

            //return list;
        }
    }
}