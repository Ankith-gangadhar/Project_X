using ProductEngine.Models;

namespace ProductEngine.Services
{
    public class ProductService
    {
        public Product CalculateProfit(Product product)
        {
            product.ProfitPerUnit = product.MRP - product.WholesalePrice;
            product.ProfitPercentage = (product.ProfitPerUnit / product.WholesalePrice) * 100;
            return product;
        }
    }
}
