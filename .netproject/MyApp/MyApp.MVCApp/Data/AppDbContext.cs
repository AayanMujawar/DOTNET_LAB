/* 
=============================================================
Exp 8: CRUD Operations Using Entity Framework Core 
=============================================================
DESCRIPTION:
This is the Database Context class. It acts as a bridge between 
our C# code and the SQLite database. Through this class, Entity 
Framework can translate our 'Customer' objects into real database tables 
(Code First Approach).
=============================================================
*/

using Microsoft.EntityFrameworkCore;
using MyApp.MVCApp.Models;

namespace MyApp.MVCApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Represents the Customers table in the database
        public DbSet<Customer> Customers { get; set; }
    }
}
