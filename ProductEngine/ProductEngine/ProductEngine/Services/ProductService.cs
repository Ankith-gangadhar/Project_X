using Microsoft.EntityFrameworkCore;
using ProductEngine.Data;
using ProductEngine.Models;
using System.Threading.Tasks;

namespace ProductEngine.Services
{
    public class ProductService
    {
        private readonly ProductEngineContext _context;

        public ProductService(ProductEngineContext context)
        {
            _context = context;
        }

        public async Task<Product> CalculateAndSaveProductAsync(Product product)
        {
            // Calculate profit
            product.ProfitPerUnit = product.MRP - product.WholesalePrice;
            product.ProfitPercentage = (product.ProfitPerUnit / product.WholesalePrice) * 100;

            // Add to DbContext and save
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

    }
}
