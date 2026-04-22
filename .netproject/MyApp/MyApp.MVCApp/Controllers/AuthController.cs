using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.MVCApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Mock Validation
            if ((email == "admin@techstore.com" && password == "admin") || 
                (email == "customer@techstore.com" && password == "customer"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, email == "admin@techstore.com" ? "Admin" : "Customer")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                if (email == "admin@techstore.com")
                    return RedirectToAction("Index", "Customers"); // Admin Dashboard
                else
                    return RedirectToAction("Index", "Home"); // Storefront
            }

            ViewBag.Error = "Invalid Credentials. Try admin@techstore.com (pw: admin) or customer@techstore.com (pw: customer)";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}
