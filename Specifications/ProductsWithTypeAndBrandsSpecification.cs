using System;
using System.Linq.Expressions;
using BabALSaray.AppEntities;

namespace BabALSaray.Specifications
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductsWithTypeAndBrandsSpecification()
        {
           AddInclude(x => x.ProductType);
           AddInclude(x => x.ProductBrand);

        }

        public ProductsWithTypeAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
           AddInclude(x => x.ProductType);
           AddInclude(x => x.ProductBrand); 
        }
    }
}