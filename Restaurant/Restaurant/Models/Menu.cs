using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Restaurant.Models
{
    public class Menu : Collection<MenuItem>
    {
        public Menu()
        {
            //Pre-load the instance of RestaurantMenu with MenuItem(s) for the demo
            Add(new MenuItem { Description = "Cheeseburger", Price = 3.99 });
            Add(new MenuItem { Description = "Hamburger", Price = 2.99 });
            Add(new MenuItem { Description = "Hot Dog", Price = 2.49 });
            Add(new MenuItem { Description = "Grilled Chicken Sandwich", Price = 4.99 });
            Add(new MenuItem { Description = "French Fries", Price = 1.29 });
            Add(new MenuItem { Description = "Onion Rings", Price = 2.29 });
            Add(new MenuItem { Description = "Soft Drink", Price = 1.19 });
            Add(new MenuItem { Description = "Coffee", Price = 0.99 });
            Add(new MenuItem { Description = "Water", Price = 0.00 });
            Add(new MenuItem { Description = "Ice Cream Cone", Price = 1.99 });
        }

        public Menu(IList<MenuItem> list)
            : base(list)
        {
        }
    }
}