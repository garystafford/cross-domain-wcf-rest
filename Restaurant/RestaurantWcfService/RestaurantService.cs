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
        public RestaurantMenu GetCurrentMenu()
        {
            //Instantiates new RestaurantMenu object and
            //sorts MeuItem objects by byDescription using LINQ
            var menuToReturn = new RestaurantMenu();

            var menuToReturnOrdered = (
                from items in menuToReturn
                orderby items.Description
                select items).ToList();

            menuToReturn = new RestaurantMenu(menuToReturnOrdered);
            return menuToReturn;
        }

        public OrderResponse SendOrder(string restaurantOrder)
        {
            //Instantiates new ProcessOrder object and
            //passes JSON-format order string to ProcessOrderJSON method
            var orderProcessor = new ProcessOrderMongo();
            var orderResponse =
                orderProcessor.ProcessOrderJson(restaurantOrder);

            return orderResponse;
        }
    }
}
