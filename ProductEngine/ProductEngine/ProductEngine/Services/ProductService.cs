using Datadog.Trace;
using ProductEngine.Interfaces;
using ProductEngine.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductEngine.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> GetProductByNameAsync(string name)
        {
            var product = await _repository.GetByNameAsync(name);
            if (product == null)
                throw new InvalidOperationException("Product not found.");
            return product;
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

            return await _repository.AddAsync(product);
        }

        public async Task<Product> UpdateProductAsync(ProductCreateDto dto)
        {
            var existing = await _repository.GetByNameAsync(dto.Name);
            if (existing == null)
                throw new InvalidOperationException("Product not found.");

            return await _repository.UpdateByNameAsync(dto.Name, dto.WholesalePrice, dto.MRP)
                   ?? throw new Exception("Update failed.");
        }
        public async Task<bool> DeleteProductAsync(string name)
        {
            var product = await _repository.GetByNameAsync(name);
            if (product == null)
                throw new InvalidOperationException("Product not found.");
            return await _repository.DeleteByNameAsync(name);
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            using (var span = Tracer.Instance.StartActive("product.get_by_name"))
            {
                return await _repository.GetAllAsync();
            }
        }
    }
}
