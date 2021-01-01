using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;

        }

        [HttpGet]

        public async Task<ActionResult<CustomerBasket>> GetBasketById (string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

           /*  And if it is then what we'll do is we'll return a new customer basket and we'll use the I.D. that the
                client has generated to give them back a new basket with an empty list of items */
            
            return Ok(basket ?? new CustomerBasket(id)); 
            

        } 

        [HttpPost]

        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updateBasket = await _basketRepository.UpdateBasketAsync(basket);

            return Ok(updateBasket);

        }

        [HttpDelete]

        public async Task DeleteBasketAsync (string id)
        {
            await _basketRepository.DeleteBasketAsync(id);

        }
    }
}