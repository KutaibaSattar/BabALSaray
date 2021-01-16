using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabALSaray.AppEntities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order()
        {
            
        }

        public Order(IReadOnlyList<OrderItem> orderItems,string buyerEmail, OrderAddress orderAddress,
         OrderMethod orderMethod,  double subtotal)
        {
            BuyerEmail = buyerEmail;
            OrderAddress = orderAddress;
            OrderMethod = orderMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
           
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }= DateTimeOffset.Now;
        public OrderAddress OrderAddress { get; set; }
        public OrderMethod  OrderMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public double Subtotal { get; set; }
        
        [Column(TypeName = "nvarchar(10)")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        public double GetTotal()
        {
           return Subtotal + OrderMethod.Price;
        }


        
    }
}