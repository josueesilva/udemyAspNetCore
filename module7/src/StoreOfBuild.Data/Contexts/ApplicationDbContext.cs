using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
        //public DbSet<Sale>  Sales{get; set;}
    }
}