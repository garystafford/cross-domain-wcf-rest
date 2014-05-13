using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Restaurant
{
    public class ProcessOrder
    {
        public const string STR_JsonFilePath = @"c:\RestaurantOrders\";

        public string ProcessOrderJSON(string restaurantOrder)
        {
            if (restaurantOrder.Length < 1)
            {
                return "Error: Empty message string...";
            }

            try
            {
                var orderId = Guid.NewGuid();
                NormalizeJsonString(ref restaurantOrder);

                //Json.NET: http://james.newtonking.com/projects/json-net.aspx
                var order =
                JsonConvert.DeserializeObject
                <RestaurantOrder>(restaurantOrder);
                WriteOrderToFile(restaurantOrder, orderId);

                return String.Format(
                "ORDER DETAILS{3}Time: {0}{3}Order Id: {1}{3}Items: {2}",
                DateTime.Now.ToLocalTime(), Guid.NewGuid(),
                order.Count(), Environment.NewLine);
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private void NormalizeJsonString(ref string restaurantOrder)
        {
            restaurantOrder = Uri.UnescapeDataString(restaurantOrder);
            int start = restaurantOrder.IndexOf("[");
            int end = restaurantOrder.IndexOf("]") + 1;
            int length = end - start;
            restaurantOrder = restaurantOrder.Substring(start, length);
        }

        private void WriteOrderToFile(string restaurantOrder, Guid OrderId)
        {
            //Make sure to add permissions for IUSR to folder path
            var fileName =
            String.Format("{0}{1}.txt", STR_JsonFilePath, OrderId);

            using (TextWriter writer = new StreamWriter(fileName))
            {
                writer.Write(restaurantOrder);
            }
        }
    }
}
