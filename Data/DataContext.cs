using System;
using System.Linq;
using System.Reflection;
using BabALSaray.AppEntities;
using BabALSaray.AppEntities.OrderAggregate;
using BabALSaray.AppEntities.Project;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BabALSaray.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>,
    AppUserRole,IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>
     >
    {
     

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

       

        public DbSet<dbAccounts> dbAccounts {get;set;}

        public DbSet<Product> Products {get;set;}

        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderMethod> OrderMethods { get; set; }
        public DbSet<Project> Projects { get; set; }
        

         protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           
            base.OnModelCreating(modelbuilder);
          
            modelbuilder.Entity<AppUser>()
                .HasMany (ur => ur.UserRoles)
                .WithOne (u => u.User)
                .HasForeignKey (ur => ur.UserId)
                .IsRequired(); 

             modelbuilder.Entity<AppRole>()
                .HasMany (ur => ur.UserRoles)
                .WithOne (u => u.Role)
                .HasForeignKey (ur => ur.RoleId)
                .IsRequired();                    
          
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
                    
                    var dateTimeProperties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset));

                    foreach (var property in properties)
                    {
                        modelbuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                      
                    }
                    foreach (var property in dateTimeProperties)
                    {
                        modelbuilder.Entity(entityType.Name).Property(property.Name).HasConversion(new DateTimeOffsetToBinaryConverter());
                      
                    }

                }
            }

        }
        
    }
}