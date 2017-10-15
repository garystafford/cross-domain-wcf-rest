using System;
using System.Runtime.Serialization;

namespace Restaurant.Models
{
    [DataContract]
    public class OrderResponse
    {
        public OrderResponse()
        {
        }

        public OrderResponse(DateTime orderDateTime, string orderItems, string orderMessage)
        {
            OrderDateTime = orderDateTime;
            OrderNumber = orderItems;
            OrderMessage = orderMessage;
        }

        [DataMember]
        public DateTime OrderDateTime { get; set; }

        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public string OrderMessage { get; set; }
    }
}