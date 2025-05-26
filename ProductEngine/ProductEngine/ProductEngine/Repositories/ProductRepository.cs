using Microsoft.EntityFrameworkCore;
using ProductEngine.Data;
using ProductEngine.Interfaces;
using ProductEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductEngine.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductEngineContext _context;

        public ProductRepository(ProductEngineContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Product?> UpdateByNameAsync(string name, decimal newWholesalePrice, decimal newMrp)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);

            if (product == null)
                return null;

            product.WholesalePrice = newWholesalePrice;
            product.MRP = newMrp;

            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
