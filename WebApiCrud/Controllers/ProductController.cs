using Microsoft.AspNetCore.Mvc;
using OA.Core.Domain;
using OA.Services;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> Products()
        {
            var porducts = await _productService.GetAllProductAsync();
            
            return Ok(porducts);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Product product)
        {
            if (product == null)
                return BadRequest();
            
            await _productService.InsertProductAsync(product);
            
            return Ok(product);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            
            return Ok(product);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (product == null)
                return BadRequest();

            product.Id = id; 

            await _productService.UpdateProductAsync(product);

            return Ok(product);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            await _productService.DeleteProductAsync(product);

            return Ok(product);
        }
    }
}
