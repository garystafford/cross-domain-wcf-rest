using Restaurant;
using Restaurant.Models;
using System.ServiceModel.Activation;

namespace RestaurantWcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode =
    AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestaurantService : IRestaurantService
    {
        public Menu GetCurrentMenu()
        {
            RestaurantMenu.BuildMenu();
            return RestaurantMenu.GetMenu();
        }

        public OrderResponse SendOrder(string restaurantOrder)
        {
            var orderProcessor = new ProcessOrder();
            return orderProcessor.ProcessOrderMongo(restaurantOrder);
        }
    }
}
