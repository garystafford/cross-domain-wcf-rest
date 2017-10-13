using System.Collections.Generic;
using MongoDB.Bson;

namespace Restaurant.Models
{
    public class Order
    {
        public Order()
        {
        }

        public Order(IList<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }

        public ObjectId Id { get; set; }

        public IList<OrderItem> OrderItems { get; set; }
    }
}