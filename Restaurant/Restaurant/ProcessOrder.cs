using System;
using System.Collections.Generic;
using System.Globalization;
using log4net;
using Newtonsoft.Json;
using Restaurant.Database;
using Restaurant.Models;

namespace Restaurant
{
    public class ProcessOrder
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProcessOrder));

        public OrderResponse ProcessOrderMongo(string restaurantOrder)
        {
            if (restaurantOrder.Length < 1)
            {
                Log.Warn("Warning: Empty order received");
                return new OrderResponse
                {
                    OrderDateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    OrderNumber = Guid.NewGuid().ToString(),
                    OrderMessage = "Sorry, empty order received?"
                };
            }

            try
            {
                NormalizeJsonString(ref restaurantOrder);

                //Json.NET: http://james.newtonking.com/projects/json-net.aspx
                var deserializeOrderObject = JsonConvert.DeserializeObject<List<OrderItem>>(restaurantOrder);

                var order = new Order(deserializeOrderObject);
                WriteOrderToMongo(order);

                Log.Info("Info: Order processed correctly");

                return new OrderResponse
                {
                    OrderDateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    OrderNumber = order.OrderNumber,
                    OrderMessage = "Thank you for your order."

                };
            }
            catch (Exception ex)
            {
                Log.Error("Error: " + ex.Message);
                return new OrderResponse
                {
                    OrderDateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    OrderNumber = Guid.NewGuid().ToString(),
                    OrderMessage = "Sorry, an error has occurred/ Please place your order again."
                };
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

        private static void WriteOrderToMongo(Order order)
        {
            var database = MongoAuthConnectionFactory.MongoDatabase("restaurant");
            //database.DropCollection("orders");
            var collectionOrders = database.GetCollection<Order>("orders");
            collectionOrders.InsertOne(order);
        }
    }
}