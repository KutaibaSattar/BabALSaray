using System.Collections.Generic;
using System.Threading.Tasks;
using AppEntities;
using BabALSaray.DTOs;

namespace BabALSaray.Interfaces
{
    public interface IProductRepository
    {
        void Update(Product product);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetProductByIdAsync (int id);
                


    }
}