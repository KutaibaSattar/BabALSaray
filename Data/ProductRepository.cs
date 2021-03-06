using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;
using BabALSaray.Specifications;
using BabALSaray.Helpers;

namespace BabALSaray.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

       /* public async Task<ProductDto> GetProductByIdAsync(int id)
        {
             return await _context.Products.Where(p => p.Id == id).
                 ProjectTo<ProductDto> (_mapper.ConfigurationProvider).FirstOrDefaultAsync(); 

                
        }
        */
        public async Task<Product> GetProductByIdAsync(int id)
        {
            /*  return await _context.Products.Where(p => p.Id == id).
                 ProjectTo<ProductDto> (_mapper.ConfigurationProvider).FirstOrDefaultAsync(); */

                 return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        /* public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
           
             return await _context.Products.ProjectTo<ProductDto> (_mapper.ConfigurationProvider).ToListAsync(); 
        }
 */
         public async Task<PagedList<ProductDto>> GetProductsAsync(ProductQueryDto productParams)
        {
           
             
             
             var query = _context.Products
                .Include(p => p.ProductType).Include(p => p.ProductBrand)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).AsNoTracking().AsQueryable();

                //query = query.Where(p => p.ProductBrand == productParams. )
                
               
               
               // Then we return page list count pageindex and pagesize
               
                return await PagedList<ProductDto>.CreateAsync(query,productParams.pageIndex,productParams.PageSize);
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() >0 ;
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified ;
        }

    }
}