using Microsoft.AspNetCore.Mvc;
using ProductEngine.Services;
using ProductEngine.Models;

namespace ProductEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    { 
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;  
        }
        
        // POST api/products
        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            var calculatedProduct = _productService.CalculateProfit(product);
            return Ok(calculatedProduct);  
        }

        // GET api/products
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A", WholesalePrice = 100, MRP = 150 },
                new Product { Id = 2, Name = "Product B", WholesalePrice = 120, MRP = 180 }
            };
            return Ok(products);
        }

    }
}
