using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private static List<Product>? _products;

        public ProductsController()
        {
            _products = new List<Product>()
            {
            new() { ProductId = 1, ProductName = "Iphone 14", Price = 60000, IsActive = true},
            new() { ProductId = 2, ProductName = "Iphone 15", Price = 70000, IsActive = true},
            new() { ProductId = 3, ProductName = "Iphone 16", Price = 80000, IsActive = true},
            new() { ProductId = 4, ProductName = "Iphone 17", Price = 90000, IsActive = true},

            };
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            if(_products == null)
            {
                return NotFound();
            }
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var p = _products?.FirstOrDefault(i => i.ProductId == id);

            if(p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }
    }
}