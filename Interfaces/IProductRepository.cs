using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.DTOs;
using BabALSaray.Helpers;
using BabALSaray.Specifications;

namespace BabALSaray.Interfaces
{
    public interface IProductRepository
    {
        void Update(Product product);

        Task<bool> SaveAllAsync();

        //Task<IEnumerable<ProductDto>> GetProductsAsync();

        Task<PagedList<ProductDto>> GetProductsAsync(ProductParams productParams);

        //Task<ProductDto> GetProductByIdAsync (int id);
        Task<Product> GetProductByIdAsync (int id);
        
        Task<IEnumerable<ProductBrand>> GetProductBrandsAsync();

        Task<IEnumerable<ProductType>> GetProductTypesAsync();
                


    }
}