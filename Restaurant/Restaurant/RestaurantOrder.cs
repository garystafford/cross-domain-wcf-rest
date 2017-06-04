using System.Collections.Generic;
using System.Collections.ObjectModel;
using MongoDB.Bson;

namespace Restaurant
{
    public class RestaurantOrder : Collection<Order>
    {
        public RestaurantOrder()
        {
            //Pre-load the instance of RestaurantOrder with OrderItem(s) for the demo
            Add(new Order(new List<OrderItem>
            {
                new OrderItem("Cheeseburger", 3.99, 2),
                new OrderItem("French Fries", 1.29, 2),
                new OrderItem("Soft Drink", 1.19, 2)
            }));

            Add(new Order(new List<OrderItem>
            {
                new OrderItem("Grilled Chicken Sandwich", 4.99, 2),
                new OrderItem("Coffee", 0.99, 1),
                new OrderItem("Water", 0.00, 1)
            }));
        }

        public RestaurantOrder(IList<Order> list)
            : base(list)
        {
        }
    }
}