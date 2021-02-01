
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Errors;
using BabALSaray.Extensions;
using BabALSaray.Helpers;
using BabALSaray.Interfaces;
using BabALSaray.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    public class ProductsController : BaseApiController
    {


        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IProductRepository _productRepository;

        public ProductsController(IMapper mapper, IProductRepository productRepository, IGenericRepository<Product> productRepo,
        IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo)


        {
           
            _productRepository = productRepository;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productRepo = productRepo;

            _mapper = mapper;

        }

        [HttpGet]
        [AllowAnonymous]
      public async Task<ActionResult<PagedList<IEnumerable<ProductDto>>>> GetProducts( [FromQuery] ProductParams productParams )
        {
          
           
           var products = await _productRepository.GetProductsAsync(productParams);

           Response.AddPaginationHeader(products.CurrentPage, products.PageSize,products.TotalCount,products.TotalPages);        
                  
            return Ok(products);

        }
        /* public async Task<ActionResult<PagedList<IEnumerable<ProductDto>>>> GetProducts( [FromQuery] ProductParams productParams )
        {
          
            var spec = new ProductsWithTypeAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);
          
           var product = await _productRepo.ListAsync(spec);

           
           var data = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(product);
          
        
            return Ok(new PagedList<ProductDto>(product,,totalItems,data));

        } */


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
           
            var spec = new ProductsWithTypeAndBrandsSpecification(id);
          
            var product = await _productRepo.GetEntityWithSpec(spec);

            if (product==null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Product,ProductDto>(product));


        }

        [HttpGet("brands")]

        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            var productbrands = await _productBrandRepo.GetAllAsync();

            return Ok(productbrands);


        }

        [HttpGet("types")]

        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            var producttypes = await _productTypeRepo.GetAllAsync();

            return Ok(producttypes);


        }


    }
}
