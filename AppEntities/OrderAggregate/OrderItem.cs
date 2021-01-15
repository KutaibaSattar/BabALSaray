namespace BabALSaray.AppEntities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public ProductItemOrdered ItemOrdered { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        
    }
}