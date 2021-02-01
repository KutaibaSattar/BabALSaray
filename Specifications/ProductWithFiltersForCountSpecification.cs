using BabALSaray.AppEntities;

namespace BabALSaray.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecifications<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductParams productParams) // count of item after filter
         : base( x =>
          (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
          (!productParams.BrandId.HasValue || x.ProdcuctBrandId == productParams.BrandId) &&
          (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)  )
        {


        }
    }
}