using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.DTOs;

namespace BabALSaray.Interfaces
{
    public interface IProductRepository
    {
        void Update(Product product);

        Task<bool> SaveAllAsync();

        //Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<IReadOnlyList<Product>> GetProductsAsync();

        //Task<ProductDto> GetProductByIdAsync (int id);
        Task<Product> GetProductByIdAsync (int id);
        
        Task<IEnumerable<ProductBrand>> GetProductBrandsAsync();

        Task<IEnumerable<ProductType>> GetProductTypesAsync();
                


    }
}