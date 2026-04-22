/* 
=============================================================
Exp 9: Development and Testing of ASP.NET Core Web API
Exp 10: Implementation of Logging and Caching
=============================================================
DESCRIPTION:
This Controller exposes our 'Products' to the outside world.
- Exp 9: Contains endpoints (GET, POST) which you can test via Postman.
- Exp 10: Uses ILogger to trace actions, and IMemoryCache to store 
  the product list in memory. If someone requests the product list 
  again within 10 seconds, it fetches from the cache instantly!
=============================================================
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MyApp.ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMemoryCache _cache;
        private const string productCacheKey = "productListKey";

        // Static list acting as our temporary database for API
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "ASUS ROG Gaming Laptop", Price = 1299.99 },
            new Product { Id = 2, Name = "Sony Noise Cancelling Headphones", Price = 348.00 },
            new Product { Id = 3, Name = "Logitech MX Master 3S Mouse", Price = 99.99 },
            new Product { Id = 4, Name = "Keychron K2 Mechanical Keyboard", Price = 79.50 }
        };

        // Injecting Logger and Cache (Exp 10)
        public ProductController(ILogger<ProductController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        // GET: api/product
        [HttpGet]
        public IActionResult GetProducts()
        {
            _logger.LogInformation("Attempting to fetch products...");

            // Checking if cache contains our data
            if (_cache.TryGetValue(productCacheKey, out List<Product> cachedProducts))
            {
                _logger.LogInformation("Fetched products instantly from CACHE!");
                return Ok(cachedProducts);
            }

            // If not in cache, fetch and add to cache
            _logger.LogInformation("Data not in cache. Fetching from database...");
            
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10)); // Cache for 10 seconds

            _cache.Set(productCacheKey, _products, cacheEntryOptions);

            return Ok(_products);
        }

        // POST: api/product (Test via Postman!)
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            _logger.LogInformation($"Adding new product: {newProduct.Name}");
            newProduct.Id = _products.Max(p => p.Id) + 1;
            _products.Add(newProduct);
            
            // Clear the cache since the list changed
            _cache.Remove(productCacheKey);

            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }
    }
}
