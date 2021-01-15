using Microsoft.EntityFrameworkCore;

namespace BabALSaray.AppEntities.OrderAggregate
{
     [Owned]
    public class OrderAddress
    {
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Country { get; set;}
        
    }
}