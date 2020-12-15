using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
             return await _context.Products.Where(p => p.Id == id).ProjectTo<ProductDto> (_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _context.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
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