using System;
using System.Linq.Expressions;
using BabALSaray.AppEntities.OrderAggregate;

namespace BabALSaray.Specifications
{
    public class OrdersWithItemsAndOrderingSpecifications : BaseSpecifications<Order>
    {
        public OrdersWithItemsAndOrderingSpecifications(string email) : base(o => o.BuyerEmail == email)
        {
            AddInclude( o => o.OrderItems);
            AddInclude( o => o.OrderMethod);
            AddOrderByDescending( o => o.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecifications(int id, string email) : base( o => o.Id == id && o.BuyerEmail == email)
        {
             AddInclude( o => o.OrderItems);
            AddInclude( o => o.OrderMethod);
            AddOrderByDescending( o => o.OrderDate);

        }
    }
}