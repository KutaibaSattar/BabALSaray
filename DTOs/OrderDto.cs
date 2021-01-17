
using DTOs;

namespace BabALSaray.Dtos
{
    public class OrderDto
    {
       public string BasketId { get; set; } 
       public int OrderMethodId { get; set; }
      public AddressDto OrderAddress { get; set; }

    }
}