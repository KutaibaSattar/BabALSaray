using System;
using System.Collections.Generic;
using BabALSaray.AppEntities.OrderAggregate;
using DTOs;

namespace BabALSaray.DTOs
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public OrderAddress OrderAddress { get; set; }
        public string  OrderMethod { get; set; }
        public decimal OrderMethodPrice { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
        public double Subtotal { get; set; }
        public decimal Total {get;set;}
        public OrderStatus Status { get; set; } 

       

        
    }
}