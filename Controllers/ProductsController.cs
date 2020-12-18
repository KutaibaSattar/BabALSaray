
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using BabALSaray.Specifications;
using Microsoft.AspNetCore.Authorization;
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
       /*  public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();

            var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(products);
 
         
        } */
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
          
            var spec = new ProductsWithTypeAndBrandsSpecification();
          
           var product = await _productRepo.ListAsync(spec);
            
            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDto>>
                     (product));

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
           
            var spec = new ProductsWithTypeAndBrandsSpecification(id);
          
            var product = await _productRepo.GetEntityWithSpec(spec);


            return Ok(_mapper.Map<Product,ProductToReturnDto>(product));


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
