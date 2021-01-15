using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabALSaray.AppEntities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public string buyerEmail { get; set; }
        public DateTimeOffset orderDate { get; set; }= DateTimeOffset.Now;
        public OrderAddress orderAddress { get; set; }
        public OrderMethod  orderMethod { get; set; }
        public IReadOnlyList<OrderItem> orderItems { get; set; }
        public decimal Subtotal { get; set; }
        
        [Column(TypeName = "nvarchar(10)")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }


        
    }
}