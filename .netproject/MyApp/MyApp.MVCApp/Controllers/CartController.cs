using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Collections.Generic;
using MyApp.MVCApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace MyApp.MVCApp.Controllers
{
    [Authorize] // Only logged in users can use the cart
    public class CartController : Controller
    {
        private const string CartSessionKey = "TechStoreCart";

        private List<CartItem> GetCartItems()
        {
            var sessionData = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(sessionData))
                return new List<CartItem>();
            
            return JsonSerializer.Deserialize<List<CartItem>>(sessionData);
        }

        private void SaveCartItems(List<CartItem> items)
        {
            HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(items));
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItem item)
        {
            var cart = GetCartItems();
            cart.Add(item);
            SaveCartItems(cart);
            return Ok(new { cartCount = cart.Count });
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            var cartCount = GetCartItems().Count;
            return Ok(new { cartCount });
        }

        public IActionResult Index()
        {
            var cart = GetCartItems();
            
            // Arithmetic Operations (Exp 1 mapped to UI constraint)!
            double subtotal = 0;
            foreach(var item in cart) { subtotal += item.Price; }
            
            double tax = subtotal * 0.18; // 18% tax
            double grandTotal = subtotal + tax;

            ViewBag.Subtotal = subtotal;
            ViewBag.Tax = tax;
            ViewBag.GrandTotal = grandTotal;

            return View(cart);
        }

        public async Task<IActionResult> Checkout()
        {
            // Simulate bank delay
            await Task.Delay(2000); 

            // Clear Cart
            HttpContext.Session.Remove(CartSessionKey);
            return View("Success");
        }
    }
}
