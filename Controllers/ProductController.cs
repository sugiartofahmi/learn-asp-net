using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learn_asp_net.Data;
using learn_asp_net.Models;
using learn_asp_net.Services;
using Microsoft.AspNetCore.Mvc;

namespace learn_asp_net.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController(ProductService productService) : ControllerBase
    {
        private readonly ProductService _productService = productService;


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            await _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product? product = await _productService.Get(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product productRequest)
        {
            Product? product = await _productService.Get(id);
            if (product is null) return NotFound();

            await _productService.Update(product, productRequest);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? product = await _productService.Get(id);
            if (product is null) return NotFound();

            await _productService.Delete(id);

            return NoContent();
        }

    }
}