namespace BabALSaray.AppEntities.OrderAggregate
{
    public class OrderMethod : BaseEntity
    {
        public string ShortName {get;set;}
        public string OrderTime { get; set; }
        public int Description { get; set; }
        public double Price { get; set; }
        
    }
}