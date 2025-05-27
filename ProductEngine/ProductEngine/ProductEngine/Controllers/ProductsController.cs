using Microsoft.AspNetCore.Mvc;
using ProductEngine.Models;
using ProductEngine.Services;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Creates a new product", Description = "Calculates and saves a new product in the database. Returns the created product details.")]
        public async Task<ActionResult<ProductCreateDto>> CreateProduct([FromBody] ProductCreateDto productcreatedto)
        {
            var savedProduct = await _productService.CalculateAndSaveProductAsync(productcreatedto);
            return Ok(savedProduct);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all products", Description = "Fetches all products from the database.")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{name}")]
        [SwaggerOperation(Summary = "Gets a product by name", Description = "Fetches a product from the database by its name.")]
        public async Task<ActionResult<Product>> GetProductByName(string name)
        {
            try
            {
                var product = await _productService.GetProductByNameAsync(name);
                if (product == null)
                {
                    return NotFound($"Product with name '{name}' not found.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [SwaggerOperation(Summary = "Updates an existing product", Description = "Updates the details of an existing product in the database.")]
        public async Task<ActionResult<ProductCreateDto>> UpdateProduct([FromBody] ProductCreateDto productcreatedto)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProductAsync(productcreatedto);
                return Ok(updatedProduct);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{name}")]
        [SwaggerOperation(Summary = "Deletes a product by name", Description = "Deletes a product from the database by its name.")]
        public async Task<ActionResult> DeleteProduct(string name)
        {
            try
            {
                var deleted = await _productService.DeleteProductAsync(name);
                if (!deleted)
                {
                    return NotFound($"Product with name '{name}' not found.");
                }
                return Ok($"'{name}' is successfully deleted ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
