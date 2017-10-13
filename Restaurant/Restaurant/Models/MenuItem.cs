using MongoDB.Bson;

namespace Restaurant.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
        }

        public MenuItem(string description, double price)
        {
            Description = description;
            Price = price;
        }

        public ObjectId Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}