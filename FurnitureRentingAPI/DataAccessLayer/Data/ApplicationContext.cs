using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class ApplicationContext : DbContext
    { 
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
        }

        protected ApplicationContext()
        { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new ProductConfiguration());
        //    modelBuilder.ApplyConfiguration(new UserConfiguration());
        //}

        //public DbSet<Products> Products { get; set; }

        //public DbSet<Users> Users { get; set; }
    }
}