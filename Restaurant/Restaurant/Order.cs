using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant
{
    public class Order
    {
        public Order()
        {
        }

        public Order(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }

        public ObjectId Id { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}