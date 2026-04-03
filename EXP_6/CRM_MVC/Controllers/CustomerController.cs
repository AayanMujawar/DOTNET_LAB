using Microsoft.AspNetCore.Mvc;
using CRM_MVC.Models;
using System.Collections.Generic;

namespace CRM_MVC.Controllers
{
    public class CustomerController : Controller
    {
        // Dummy data (no database)
        public IActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "John", Email = "john@gmail.com", Phone = "1234567890" },
                new Customer { Id = 2, Name = "Alice", Email = "alice@gmail.com", Phone = "9876543210" }
            };

            return View(customers);
        }
    }
}