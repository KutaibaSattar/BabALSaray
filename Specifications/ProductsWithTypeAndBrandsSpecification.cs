using System;
using System.Linq.Expressions;
using BabALSaray.AppEntities;

namespace BabALSaray.Specifications
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductsWithTypeAndBrandsSpecification(string sort)
        {
           AddInclude(x => x.ProductType);
           AddInclude(x => x.ProductBrand);
           AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))

            {

                switch (sort)
                {

                    case "priceAsc":
                        AddOrderBy(p => p.price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.price);
                        break;
                   
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }

            }
         
          
           
        }

        public ProductsWithTypeAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
           AddInclude(x => x.ProductType);
           AddInclude(x => x.ProductBrand); 
        }
    }
}