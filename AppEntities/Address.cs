using Microsoft.EntityFrameworkCore;

namespace BabALSaray.AppEntities
{
    [Owned]
    public class Address
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
       

    }
}