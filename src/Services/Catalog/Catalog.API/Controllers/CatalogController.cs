using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger) { 
        
            _productRepository= productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger= logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //TODO mongo db image docker etc.
        //Test apis

        // we'll use IActionResult to resilience it
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        { 
            var products = await _productRepository.GetProducts();

            if(!products.Any())
                return NotFound("Product not found");

            return Ok(products);
        }

        [HttpGet("{id}:length(24)",Name = "GetProduct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == null)
            {
                  _logger.LogError($"Product with id: {id}, not found.");
                return NotFound("Product not found");
            }
            return Ok(product);
        }


        [Route("[action]/{category}",Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string categoryName)
        {
            var products = await _productRepository.GetProductsByCategory(categoryName);

            if (!products.Any())
            {
                _logger.LogError($"Product with categoryName: {categoryName}, not found.");
                return NotFound("Product not found");
            }

            return Ok(products);
        }


        [Route("[action]/{name}", Name = "GetProductByName")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var items = await _productRepository.GetProductsByName(name);
            if (items == null)
            {
                _logger.LogError($"Products with name: {name} not found.");
                return NotFound();
            }
            return Ok(items);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _productRepository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);

        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result =  await _productRepository.UpdateProduct(product);

            return Ok(result);

        }


        [HttpDelete("{id}:length(24)", Name = "DeleteProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productRepository.DeleteProduct(id);

            return Ok(result);

        }


    }
}
