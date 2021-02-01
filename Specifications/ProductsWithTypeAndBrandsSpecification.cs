using System;
using System.Linq.Expressions;
using BabALSaray.AppEntities;

namespace BabALSaray.Specifications
{
    public class ProductsWithTypeAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductsWithTypeAndBrandsSpecification(ProductParams productParams )
        : base( x =>
           (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
          (!productParams.BrandId.HasValue || x.ProdcuctBrandId == productParams.BrandId) &&
          (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)  )
        {
           AddInclude(x => x.ProductType);
           AddInclude(x => x.ProductBrand);
           AddOrderBy(x => x.Name);

           ApplyPaging(productParams.PageSize * (productParams.pageIndex-1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))

            {

                switch (productParams.Sort)
                {

                    case "PriceAsc":
                        AddOrderBy(p => p.price);
                        break;

                    case "PriceDesc":
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