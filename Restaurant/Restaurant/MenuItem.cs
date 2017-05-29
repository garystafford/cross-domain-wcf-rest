namespace Restaurant
{
    public class MenuItem
    {
        public MenuItem()
        {
        }

        public MenuItem(int id, string description, double price)
        {
            Id = id;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}