using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Restaurant.Models
{
    public class Order : Collection<OrderItem>
    {
        public Order()
        {
        }

        public Order(IList<OrderItem> orderItems)
            : base(orderItems)
        {
        }
    }
}