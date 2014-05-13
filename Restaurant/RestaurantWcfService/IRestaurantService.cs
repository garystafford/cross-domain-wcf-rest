using Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

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
        RestaurantMenu GetCurrentMenu();

        [OperationContract]
        [Description("Accepts a menu order and return an order confirmation.")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "SendOrder?restaurantOrder={restaurantOrder}")]
        string SendOrder(string restaurantOrder);
    }
}
