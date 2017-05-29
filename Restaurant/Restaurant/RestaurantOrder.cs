using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Restaurant
{
    public class RestaurantOrder : Collection<OrderItem>
    {
        public RestaurantOrder(IList<OrderItem> list)
            : base(list)
        {
        }
    }
}