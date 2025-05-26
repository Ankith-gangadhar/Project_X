using Microsoft.EntityFrameworkCore;
using ProductEngine.Data;
using ProductEngine.Models;
using System.Collections.Generic;
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

        public async Task<Product> CalculateAndSaveProductAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                WholesalePrice = dto.WholesalePrice,
                MRP = dto.MRP,
                ProfitPerUnit = dto.MRP - dto.WholesalePrice,
                ProfitPercentage = dto.WholesalePrice == 0 ? 0 : ((dto.MRP - dto.WholesalePrice) / dto.WholesalePrice) * 100
            };

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
