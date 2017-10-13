using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using MongoDB.Bson;
using MongoDB.Driver;
using Restaurant.Models;

namespace Restaurant
{
    public class MongoDbTest
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProcessOrder));

        public async Task<List<MenuItem>> TestMongo()
        {
            var mongoConnectionFactory = new MongoAuthConnectionFactory();
            var database = mongoConnectionFactory.MongoDatabase("restaurant");
            Log.Info(database.Settings.ToString());

            var collectionMenuItems = database.GetCollection<MenuItem>("menuItems");
            await collectionMenuItems.DeleteManyAsync(x => x.Description != "");
            await collectionMenuItems.InsertManyAsync(new RestaurantMenu());
            await collectionMenuItems.InsertOneAsync(new MenuItem("Tofu", 3.49));

            var collectionOrders = database.GetCollection<Order>("orders");
            await collectionOrders.DeleteManyAsync(x => x.Id != ObjectId.Empty);
            var orderItems = new List<OrderItem>
            {
                new OrderItem("Tea", 2.99, 2),
                new OrderItem("Fudge Bar", 1.29, 1)
            };
            await collectionOrders.InsertOneAsync(new Order(orderItems));


            var list = await collectionMenuItems
                .Find(x => x.Description == "Tofu")
                .ToListAsync();

            foreach (var menuItem in list)
                Console.WriteLine(menuItem.Description);

            return list;
        }
    }
}