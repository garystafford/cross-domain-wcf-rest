
namespace Restaurant
{
    public class OrderItem
    {
        public OrderItem()
        {
        }

        public OrderItem(int Id, int Quantity)
        {
            this.Id = Id;
            this.Quantity = Quantity;
        }

        public int Id { get; private set; }

        public int Quantity { get; private set; }
    }
}
