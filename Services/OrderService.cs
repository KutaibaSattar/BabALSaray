
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.AppEntities.OrderAggregate;
using BabALSaray.Interfaces;

namespace BabALSaray.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<OrderMethod> _orderMethodRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepository;

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<OrderMethod> orderMethodRepo,
         IGenericRepository<Product> productRepo, IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
            _productRepo = productRepo;
            _orderMethodRepo = orderMethodRepo;
            _orderRepo = orderRepo;

        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int OrderMethodId, string basketId, OrderAddress orderAddress)
        {
            // get basket from the repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
            // get items from product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                var itemOrder = new ProductItemOrdered(productItem.Id,productItem.Name,productItem.PictureUrl);
                var OrderItem = new OrderItem(itemOrder, decimal.ToDouble(productItem.price) , decimal.ToDouble(item.Quantity));
                items.Add(OrderItem);
            }

            // get delivery method from repo
            var orderMethod = await _orderMethodRepo.GetByIdAsync(OrderMethodId);

            // calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // create order
            var order = new Order(items , buyerEmail, orderAddress,orderMethod,subtotal);
            // save to db
            
            // retyrn order
            return order;

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