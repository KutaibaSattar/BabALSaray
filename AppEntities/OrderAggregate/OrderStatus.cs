using System.Runtime.Serialization;

namespace BabALSaray.AppEntities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value="Pending")]
        Pending,
        
        [EnumMember(Value="Paymnet Received")]
        PaymnetReceived,
       
        [EnumMember(Value="Paymnet Faild")]
        PaymnetFaild,
        
        [EnumMember(Value="Shipped")]
        Shipped
        
    }
}