using Microsoft.AspNetCore.Mvc;
using ProductEngine.Models;
using ProductEngine.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<ActionResult<ProductCreateDto>> CreateProduct([FromBody] ProductCreateDto productcreatedto)
        {
            var savedProduct = await _productService.CalculateAndSaveProductAsync(productcreatedto);
            return Ok(savedProduct);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // Now load products from database asynchronously
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
    }
}
