using System;
using System.Runtime.Serialization;

namespace Restaurant
{
    [DataContractAttribute]
    public class OrderResponse
    {
        public OrderResponse(String OrderTime, Guid OrderId, 
            int ItemCount, String OrderMessage)
        {
            this.OrderTime = OrderTime;
            this.OrderId = OrderId;
            this.ItemCount = ItemCount;
            this.OrderMessage = OrderMessage;
        }

        [DataMember]
        public String OrderTime { get; private set; }

        [DataMember]
        public Guid OrderId { get; private set; }

        [DataMember]
        public int ItemCount { get; private set; }

        [DataMember]
        public string OrderMessage { get; private set; }
    }
}
