using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.OrderAggregate;

namespace Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync ( string buyerEmail, int OrderMethod, string basketId, OrderAddress shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync (int id, string buyerEmail);
        Task<IReadOnlyList<OrderMethod>> GetDeliveryMethodAsync();
        
    }
}