using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Restaurant
{
    public class MongoDbTest
    {
        public async Task<List<MenuItem>> TestMongo()
        {
            var client = new MongoClient("mongodb://13.92.188.80:27017");
            var database = client.GetDatabase("restaurant");

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


            var list = await collectionMenuItems.Find(x => x.Description == "Tofu")
                .ToListAsync();

            foreach (var menuItem in list)
                Console.WriteLine(menuItem.Description);

            return list;
        }
    }
}