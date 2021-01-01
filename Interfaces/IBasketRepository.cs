
using System.Threading.Tasks;
using BabALSaray.AppEntities;

namespace BabALSaray.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync (CustomerBasket basket);
        Task<bool> DeleteBasketAsync (string basketId);
         
    }
}