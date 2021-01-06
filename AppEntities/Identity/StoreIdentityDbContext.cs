using BabALSaray.AppEntities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.AppEntities.Identity
{
    public class StoreIdentityDbContext : IdentityDbContext<StoreUser>
    {
         /* we don't need to add any D.B. sets inside here.
        Our identity DB context is taken care of all of this work for us and that's why we derive from this one. */
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) : base(options)
        {


        }

      /*   If we don't do this we get issues with identity and the primary killer it's using for the I.D. of the
            app user field. */   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}