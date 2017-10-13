using Restaurant;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using Restaurant.Models;

namespace RestaurantWcfService
{
    [ServiceContract]
    public interface IRestaurantService
    {
        [OperationContract]
        [Description("Returns a copy of the restaurant menu.")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        Menu GetCurrentMenu();

        [OperationContract]
        [Description("Accepts a menu order and return an order confirmation.")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SendOrder?restaurantOrder={restaurantOrder}")]
        OrderResponse SendOrder(string restaurantOrder);
    }
}
