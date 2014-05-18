
namespace Restaurant
{
    public class MenuItem
    {
        public MenuItem()
        {
        }

        public MenuItem(int Id, string Description, double Price)
        {
            this.Id = Id;
            this.Description = Description;
            this.Price = Price;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
