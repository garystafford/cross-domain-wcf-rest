using System;
using System.Globalization;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;

namespace Restaurant
{
    public class ProcessOrder
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ProcessOrder));

        public const string StrJsonFilePath = @"c:\RestaurantOrders\";

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
                var order = JsonConvert.DeserializeObject<RestaurantOrder>(restaurantOrder);

                WriteOrderToFile(restaurantOrder, orderId);

                return new OrderResponse(
                    DateTime.Now.ToLocalTime().ToString(CultureInfo.InvariantCulture),
                    orderId, order.Count(), "Thank you for your order!");
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

        private static void WriteOrderToFile(string restaurantOrder, Guid orderId)
        {
            //Make sure to add permissions for IUSR to folder path
            var fileName = $"{StrJsonFilePath}{orderId}.txt";

            using (TextWriter writer = new StreamWriter(fileName))
            {
                writer.Write(restaurantOrder);
            }
        }
    }
}