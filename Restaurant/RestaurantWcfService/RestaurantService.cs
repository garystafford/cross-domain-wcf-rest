using Restaurant;
using System.Linq;
using System.ServiceModel.Activation;
using Restaurant.Models;

namespace RestaurantWcfService
{
    [AspNetCompatibilityRequirements(RequirementsMode =
    AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestaurantService : IRestaurantService
    {
        public Menu GetCurrentMenu()
        {
            RestaurantMenu.BuildMenu();
            return RestaurantMenu.GetMenu(); ;
        }

        public OrderResponse SendOrder(string restaurantOrder)
        {
            var orderProcessor = new ProcessOrder();
            return orderProcessor.ProcessOrderMongo(restaurantOrder);
        }
    }
}
