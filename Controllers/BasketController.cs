using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;

        }

        [HttpGet]

        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            /*  And if it is then what we'll do is we'll return a new customer basket and we'll use the I.D. that the
                 client has generated to give them back a new basket with an empty list of items */

            return Ok(basket ?? new CustomerBasket(id));


        }

        [HttpPost]

        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
           
          var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);

         var updateBasket = await _basketRepository.UpdateBasketAsync(customerBasket);

         return Ok(updateBasket);

        }

        [HttpDelete]

        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);

        }
    }
}