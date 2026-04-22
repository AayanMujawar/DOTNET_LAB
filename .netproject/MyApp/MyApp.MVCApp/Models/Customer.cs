/* 
=============================================================
Exp 7: Data Annotation Validation in ASP.NET Core MVC
=============================================================
DESCRIPTION:
This is the Customer model. We use Data Annotations like [Required],
[StringLength], and [EmailAddress] to automatically validate 
any user input before it reaches the database.
=============================================================
*/

using System.ComponentModel.DataAnnotations;

namespace MyApp.MVCApp.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Customer must be 18 or older to purchase.")]
        public int Age { get; set; }
    }
}
