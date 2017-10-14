using System;
using System.Runtime.Serialization;
using MongoDB.Bson;

namespace Restaurant.Models
{
    [DataContract]
    public class OrderResponse
    {
        public OrderResponse(string orderTime, ObjectId orderId, string orderMessage)
        {
            OrderTime = orderTime;
            OrderId = orderId;
            OrderMessage = orderMessage;
        }

        [DataMember]
        public string OrderTime { get; private set; }

        [DataMember]
        public ObjectId OrderId { get; private set; }

        [DataMember]
        public string OrderMessage { get; private set; }
    }
}