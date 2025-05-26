using ProductEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductEngine.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product?> UpdateByNameAsync(string name, decimal newWholesalePrice, decimal newMRP);
        Task<bool> DeleteByNameAsync(string name);
        Task<Product?> GetByNameAsync(string name);
    }
}
