using System.Collections.Generic;

namespace BabALSaray.AppEntities
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
            
        }

        public CustomerBasket(string id)
        {
            this.Id = id;

        }
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>(); // creating empty list of items when creating a basket
    }
}