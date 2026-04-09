using Microsoft.EntityFrameworkCore;
using EFCoreCRUD.Models;

namespace EFCoreCRUD.Data
{
    // DbContext class - Represents a session with the database
    // EF Core uses this to query and save data
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet represents the collection of Students in the database (maps to the Students table)
        public DbSet<Student> Students { get; set; }

        // Seed initial data using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Aayan Mujawar",
                    Email = "aayan@example.com",
                    Course = "Computer Science",
                    EnrollmentDate = new DateTime(2024, 8, 1)
                },
                new Student
                {
                    Id = 2,
                    Name = "Rahul Sharma",
                    Email = "rahul@example.com",
                    Course = "Information Technology",
                    EnrollmentDate = new DateTime(2024, 8, 1)
                },
                new Student
                {
                    Id = 3,
                    Name = "Priya Patel",
                    Email = "priya@example.com",
                    Course = "Electronics",
                    EnrollmentDate = new DateTime(2024, 7, 15)
                }
            );
        }
    }
}
