using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using log4net;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Restaurant.Models;

namespace Restaurant
{
    public class ProcessOrderMongo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProcessOrder));

        public OrderResponse ProcessOrderJson(string restaurantOrder)
        {
            var orderId = Guid.NewGuid();

            if (restaurantOrder.Length < 1)
            {
                Log.Info("Error: Empty message string...");
                return new OrderResponse(
                    DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture), orderId,
                    0, "Sorry, empty order received.");
            }

            try
            {
                NormalizeJsonString(ref restaurantOrder);

                //Json.NET: http://james.newtonking.com/projects/json-net.aspx
                var order = JsonConvert.DeserializeObject<List<OrderItem>>(restaurantOrder);
                
                var orderItems = new Order(order);

                WriteOrderToMongo(orderItems, orderId);

                return new OrderResponse(
                    DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture),
                    orderId, 0, "Thank you for your order!");
            }
            catch (Exception ex)
            {
                Log.Info("Error: " + ex.Message);
                return new OrderResponse(
                    DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture), orderId, 0, ex.Message);
            }
        }

        private static void NormalizeJsonString(ref string restaurantOrder)
        {
            restaurantOrder = Uri.UnescapeDataString(restaurantOrder);
            var start = restaurantOrder.IndexOf("[", StringComparison.InvariantCulture);
            var end = restaurantOrder.IndexOf("]", StringComparison.InvariantCulture) + 1;
            var length = end - start;
            restaurantOrder = restaurantOrder.Substring(start, length);
        }

        private static async void WriteOrderToMongo(Order order, Guid orderId)
        {
            var mongoConnectionFactory = new MongoAuthConnectionFactory();
            var database = mongoConnectionFactory.MongoDatabase("restaurant");

            var collectionOrders = database.GetCollection<Order>("orders");
            await collectionOrders.InsertOneAsync(order);
        }
    }
}