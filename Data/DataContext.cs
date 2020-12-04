using AppEntities;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<dbAccounts>()
                .HasMany(p => p.Children)
                .WithOne(p => p.Parent)
               .HasForeignKey( p => p.ParentId);

               
        }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<dbAccounts> dbAccounts {get;set;} 
    }
}