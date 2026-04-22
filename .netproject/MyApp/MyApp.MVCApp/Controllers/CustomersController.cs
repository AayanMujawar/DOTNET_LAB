/* 
=============================================================
Exp 8: CRUD Operations Using Entity Framework Core
=============================================================
DESCRIPTION:
This Controller handles all the HTTP Requests for Customers.
It interacts with the database (AppDbContext) to Create, Read, 
Update, and Delete data.
=============================================================
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyApp.MVCApp.Data;
using MyApp.MVCApp.Models;
using System.Linq;

namespace MyApp.MVCApp.Controllers
{
    // Only Admins can access this Controller!
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // READ 
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // CREATE 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer); 
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
