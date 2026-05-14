using Microsoft.AspNetCore.Mvc;
using EcomAPI.Models;

namespace EcomAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "iPhone", Price = 80000, Description = "Apple phone", Stock = 10 },
            new Product { Id = 2, Name = "Laptop", Price = 60000, Description = "Gaming laptop", Stock = 5 }
        };

        // GET all
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        // GET by Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);

            return Ok(product);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            product.Stock = updatedProduct.Stock;

            return Ok(product);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            products.Remove(product);

            return Ok("Deleted successfully");
        }
    }
}