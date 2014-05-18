using System.Collections.ObjectModel;
using System.Collections.Generic;

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
