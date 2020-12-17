using BabALSaray.AppEntities;

namespace BabALSaray.DTOs
{
    public class ProductDto
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal price { get; set; }  

        public string PictureUrl { get; set; }

         public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

       
        public int ProdcuctBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

       
    }
}