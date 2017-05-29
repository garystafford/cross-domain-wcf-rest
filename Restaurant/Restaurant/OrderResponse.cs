using System;
using System.Runtime.Serialization;

namespace Restaurant
{
    [DataContract]
    public class OrderResponse
    {
        public OrderResponse(string orderTime, Guid orderId,
            int itemCount, string orderMessage)
        {
            OrderTime = orderTime;
            OrderId = orderId;
            ItemCount = itemCount;
            OrderMessage = orderMessage;
        }

        [DataMember]
        public string OrderTime { get; private set; }

        [DataMember]
        public Guid OrderId { get; private set; }

        [DataMember]
        public int ItemCount { get; private set; }

        [DataMember]
        public string OrderMessage { get; private set; }
    }
}