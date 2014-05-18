using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Restaurant
{
    public class ProcessOrder
    {
        public const string STR_JsonFilePath = @"c:\RestaurantOrders\";
        public OrderResponse ProcessOrderJSON(string restaurantOrder)
        {
            var orderId = Guid.NewGuid(); 
            
            if (restaurantOrder.Length < 1)
            {
                Console.WriteLine("Error: Empty message string...");
                return new OrderResponse(
                    DateTime.Now.ToLocalTime().ToString(), orderId, 
                    0, "Sorry, empty order received.");
            }

            try
            {
                NormalizeJsonString(ref restaurantOrder);

                //Json.NET: http://james.newtonking.com/projects/json-net.aspx
                var order = JsonConvert.DeserializeObject<RestaurantOrder>(restaurantOrder);

                WriteOrderToFile(restaurantOrder, orderId);

                return new OrderResponse(
                    DateTime.Now.ToLocalTime().ToString(), 
                    orderId, order.Count(), "Thank you for your order!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new OrderResponse(
                    DateTime.Now.ToLocalTime().ToString(), orderId, 0, ex.Message);
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
            var fileName = String.Format("{0}{1}.txt", STR_JsonFilePath, OrderId);

            using (TextWriter writer = new StreamWriter(fileName))
            {
                writer.Write(restaurantOrder);
            }
        }
    }
}
