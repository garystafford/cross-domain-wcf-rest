namespace Restaurant.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(string description, double price, int quantity)
        {
            Price = price;
            Description = description;
            Quantity = quantity;
        }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}