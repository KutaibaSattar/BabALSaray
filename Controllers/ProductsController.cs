
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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



    }
}
