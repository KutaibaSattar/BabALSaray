using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities.OrderAggregate;
using BabALSaray.Dtos;
using BabALSaray.Errors;
using BabALSaray.Extensions;
using BabALSaray.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    //[Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;

        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var address = _mapper.Map<AddressDto, OrderAddress>(orderDto.OrderAddress);

            var order = await _orderService.CreateOrderAsync(email, orderDto.OrderMethodId,orderDto.BasketId,address);

            if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order"));
            
            return Ok(order);

        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrdersForUser()
        {
           var email = HttpContext.User.RetrieveEmailFromPrincipal();

           var orders = await _orderService.GetOrdersForUserAsync(email);

           return Ok(orders);

        }

         [HttpGet("{id}")]

         public async Task<ActionResult<Order>> GetOrderByIdForUser(int id)
         {
             var email = HttpContext.User.RetrieveEmailFromPrincipal();

             var order =  await _orderService.GetOrderByIdAsync(id, email);

             if (order == null) return NotFound (new ApiResponse(404));

                return order;


         }

         [HttpGet("OrdrMethod")]

         public async Task<ActionResult<IReadOnlyList<OrderMethod>>> GetOrderMethods()
         {
             return Ok(await _orderService.GetOrderMethodAsync());
         }

    }

}