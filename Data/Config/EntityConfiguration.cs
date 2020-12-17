using BabALSaray.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BabALSaray.Data.Config
{
    public abstract class BaseEntityTypeConfiguration <TBase> : IEntityTypeConfiguration<TBase>
        where TBase : BaseEntity
    {

          public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            throw new System.NotImplementedException();
        }

    
    }

    public class ProductConfiguration : BaseEntityTypeConfiguration<Product>
    {
            
                 public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.price).HasColumnType("decimal(18,2)");
                       
             builder.HasOne(b => b.ProductBrand).WithMany()
                 .HasForeignKey(p => p.ProdcuctBrandId);
           
            builder.HasOne(b => b.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);

        }
  
    }

    public class ProductTypeConfiguration : BaseEntityTypeConfiguration<ProductType>
    {
            
           public override void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(pt => pt.Id).IsRequired();
            builder.Property(pt => pt.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(pt => pt.Name).IsUnique();
                   

        }
  
    }

    public class ProductBrandConfiguration : BaseEntityTypeConfiguration<ProductBrand>
    {
            
           public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(pb => pb.Id).IsRequired();
            builder.Property(pb => pb.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(pb => pb.Name).IsUnique();
                   

        }
  
    }

}