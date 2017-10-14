using Restaurant.Models;

namespace Restaurant
{
    public static class BuildMenu
    {
        public static void AddMenuToMongo()
        {
            var menu = new Menu()
            {
                new MenuItem {Description = "Cheeseburger", Price = 3.99},
                new MenuItem {Description = "Hamburger", Price = 2.99},
                new MenuItem {Description = "Hot Dog", Price = 2.49},
                new MenuItem {Description = "Grilled Chicken Sandwich", Price = 4.99},
                new MenuItem {Description = "French Fries", Price = 1.29},
                new MenuItem {Description = "Onion Rings", Price = 2.29},
                new MenuItem {Description = "Soft Drink", Price = 1.19},
                new MenuItem {Description = "Coffee", Price = 0.99},
                new MenuItem {Description = "Water", Price = 0.00},
                new MenuItem {Description = "Ice Cream Cone", Price = 1.99}
            };
            var database = MongoAuthConnectionFactory.MongoDatabase("restaurant");
            var collectionMenuItems = database.GetCollection<MenuItem>("menu");
            collectionMenuItems.InsertMany(menu);
        }


    }
}