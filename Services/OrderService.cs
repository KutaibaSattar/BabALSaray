
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.AppEntities.OrderAggregate;
using BabALSaray.Interfaces;
using BabALSaray.Specifications;

namespace BabALSaray.Services
{
    public class OrderService : IOrderService
    {
       /*  private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<OrderMethod> _orderMethodRepo;
        private readonly IGenericRepository<Product> _productRepo; */
        private readonly IBasketRepository _basketRepository;
        private readonly IunitOfWork _unitOfWork;


       /*  public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<OrderMethod> orderMethodRepo,
         IGenericRepository<Product> productRepo, IBasketRepository basketRepository) */
         public OrderService( IBasketRepository basketRepository, IunitOfWork unitOfWork)
        {
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
           /*  _productRepo = productRepo;
            _orderMethodRepo = orderMethodRepo;
            _orderRepo = orderRepo; */

        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int OrderMethodId, string basketId, OrderAddress orderAddress)
        {
            // get basket from the repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
            // get items from product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrder = new ProductItemOrdered(productItem.Id,productItem.Name,productItem.PictureUrl);
                var OrderItem = new OrderItem(itemOrder, productItem.price , item.Quantity);
                items.Add(OrderItem);
            }

            // get order method from repo
            //var orderMethod = await _orderMethodRepo.GetByIdAsync(OrderMethodId);
            var orderMethod = await _unitOfWork.Repository<OrderMethod>().GetByIdAsync(OrderMethodId);

            // calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // create order
            var order = new Order(items , buyerEmail, orderAddress,orderMethod,subtotal);
           _unitOfWork.Repository<Order>().Add(order); // memory
            // save to db
           /* because our units of work owns our context.
            Any changes that attract by entity framework are going to be saved into our database at this point.
            we guarantee in this unit of work is that all of the changes in this method are going to be
            applied or none of them. */
           var result = await _unitOfWork.Complete();

           if (result <=0) return null;

           // delete basket
           await _basketRepository.DeleteBasketAsync(basketId);
           // return order
            return order;

        }

        public async Task<IEnumerable<OrderMethod>> GetOrderMethodAsync()
        {
             return await  _unitOfWork.Repository<OrderMethod>().ListAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersItemsOrderingQuery(id, buyerEmail);

            return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IEnumerable<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersItemsOrderingQuery(buyerEmail);

            return await _unitOfWork.Repository<Order>().ListAsync(spec);
        }
    }
}