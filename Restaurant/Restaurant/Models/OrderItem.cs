using MongoDB.Bson.Serialization.Attributes;

namespace Restaurant.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(int quantity, string description, double price)
        {
            Quantity = quantity;
            Price = price;
            Description = description;
        }


        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }
    }
}