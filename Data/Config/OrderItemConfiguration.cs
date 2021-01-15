using BabALSaray.AppEntities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderItem> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}