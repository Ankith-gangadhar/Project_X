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
    }
}
