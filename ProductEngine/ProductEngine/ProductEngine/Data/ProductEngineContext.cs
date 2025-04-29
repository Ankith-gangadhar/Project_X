using Microsoft.EntityFrameworkCore;
using ProductEngine.Models;

namespace ProductEngine.Data
{
    public class ProductEngineContext : DbContext
    {
        public ProductEngineContext(DbContextOptions<ProductEngineContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
