using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.Models;

namespace Repository.Concrete
{
    public class EGardenerContext : IdentityDbContext<IdentityUser>
    {
        public EGardenerContext(DbContextOptions<EGardenerContext> options)
            : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }


    class EGardenerContextFactory : IDesignTimeDbContextFactory<EGardenerContext>
    {
       
        public EGardenerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EGardenerContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EGarden; user id=sa; password=Password0;Trusted_Connection=False;MultipleActiveResultSets=true;");

            return new EGardenerContext(optionsBuilder.Options);
        }
    }
}
