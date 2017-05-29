using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Restaurant
{
    public class RestaurantMenu : Collection<MenuItem>
    {
        public RestaurantMenu()
        {
            //Pre-load the instance of RestaurantMenu with MenuItem(s) for the demo
            Add(new MenuItem { Id = 1, Description = "Cheeseburger", Price = 3.99 });
            Add(new MenuItem { Id = 2, Description = "Hamburger", Price = 2.99 });
            Add(new MenuItem { Id = 3, Description = "Hot Dog", Price = 2.49 });
            Add(new MenuItem { Id = 4, Description = "Grilled Chicken Sandwich", Price = 4.99 });
            Add(new MenuItem { Id = 5, Description = "French Fries", Price = 1.29 });
            Add(new MenuItem { Id = 5, Description = "Onion Rings", Price = 2.29 });
            Add(new MenuItem { Id = 6, Description = "Soft Drink", Price = 1.19 });
            Add(new MenuItem { Id = 7, Description = "Coffee", Price = 0.99 });
            Add(new MenuItem { Id = 8, Description = "Water", Price = 0.00 });
            Add(new MenuItem { Id = 9, Description = "Ice Cream Cone", Price = 1.99 });
        }

        public RestaurantMenu(IList<MenuItem> list)
            : base(list)
        {
        }
    }
}