
using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.OrderAggregate;
using Interfaces;

namespace Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> CreateOrderAsync(string buyerEmail, int OrderMethod, string basketId, OrderAddress shippingAddress)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<OrderMethod>> GetDeliveryMethodAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }
    }
}