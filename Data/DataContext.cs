using System.Linq;
using System.Reflection;
using BabALSaray.AppEntities;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<dbAccounts> dbAccounts {get;set;}

        public DbSet<Product> Products {get;set;}

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

         protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
           /*  builder.Entity<dbAccounts>()
                .HasMany(p => p.Children)
                
                .WithOne(p => p.Parent)
               .HasForeignKey( p => p.ParentId); */
              // builder.Entity<dbAccounts>().OwnsOne(a => a.Address);
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelbuilder.Model.GetEntityTypes() )
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelbuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }

                }
            }

        }
        
    }
}