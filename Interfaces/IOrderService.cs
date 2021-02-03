using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities.OrderAggregate;

namespace BabALSaray.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync ( string buyerEmail, int OrderMethod, string basketId, OrderAddress shippingAddress);
        Task<IEnumerable<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync (int id, string buyerEmail);
        Task<IEnumerable<OrderMethod>> GetOrderMethodAsync();
        
    }
}