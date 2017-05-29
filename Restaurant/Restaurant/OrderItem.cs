namespace Restaurant
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public int Id { get; }

        public int Quantity { get; }
    }
}