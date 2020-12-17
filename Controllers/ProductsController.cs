
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    public class ProductsController : BaseApiController
    {
       
       
        private readonly IMapper _mapper;
        private readonly IProductRepository _ProductRepository;

        public ProductsController(IMapper mapper, IProductRepository productRepository)
        
        
        {
           
            _ProductRepository = productRepository;
             _mapper = mapper;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _ProductRepository.GetProductsAsync();
                        
            return Ok(products);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _ProductRepository.GetProductByIdAsync(id);

            var productToReturn = _mapper.Map<ProductDto>(product);

            return Ok(productToReturn);


        }

        [HttpGet("brands")]

         public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            var productbrands = await _ProductRepository.GetProductBrandsAsync();
                        
            return Ok(productbrands);


        }

        [HttpGet("types")]

         public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            var producttypes = await _ProductRepository.GetProductTypesAsync();
                        
            return Ok(producttypes);


        }



    }
}
