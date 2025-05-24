using ProductEngine.Models;

namespace ProductEngine.Interfaces
{
    public interface IProductService
    {
        Product CalculateProfit(Product product);

    }
}
