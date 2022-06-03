using Core.entities;
using Infrastructure.data.config;
using Microsoft.EntityFrameworkCore;

namespace API.data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductsBrand { get; set; }
        public DbSet<ProductType> ProductsType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}