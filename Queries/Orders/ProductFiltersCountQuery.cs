using BabALSaray.AppEntities;

namespace BabALSaray.Specifications
{
    public class ProductFiltersCountQuery : GenericQuery<Product>
    {
        public ProductFiltersCountQuery(ProductQueryDto productParams) // count of item after filter
         : base( x =>
          (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
          (!productParams.BrandId.HasValue || x.ProdcuctBrandId == productParams.BrandId) &&
          (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)  )
        {


        }
    }
}