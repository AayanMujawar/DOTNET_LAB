/* 
=============================================================
CONSOLE APP MODULE (Covers Experiments 1 to 5)
=============================================================
DESCRIPTION:
This console app demonstrates the core backend logic 
for our E-Commerce System. It processes an order, 
calculates the bill, and simulates payment.

EXPERIMENT MAPPING:
Exp 1 (Basic C# & Arithmetic): Calculating Total + Tax (CalculateBill method).
Exp 2 (OOP Concepts): Using 'Customer' and 'Order' objects.
Exp 3 (SOLID - SRP): The 'PaymentProcessor' class handles ONLY payments.
Exp 4 (Delegates / Lambdas): Sending a notification when an order is successful.
Exp 5 (Async / Await): A 3-second simulation 'Task.Delay' for bank validation.
=============================================================
*/

using System;
using System.Threading.Tasks;

namespace MyApp.ConsoleApp
{
    // Exp 2: Object-Oriented Programming (Classes and Encapsulation)
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class Order
    {
        public Customer OrderCustomer { get; set; }
        public double Subtotal { get; set; }

        public Order(Customer customer, double subtotal)
        {
            OrderCustomer = customer;
            Subtotal = subtotal;
        }

        // Exp 1: Arithmetic Operations
        public double CalculateFinalBill()
        {
            double tax = Subtotal * 0.18; // 18% Tax
            double grandTotal = Subtotal + tax;
            return grandTotal;
        }
    }

    // Exp 3: SOLID (Single Responsibility Principle)
    // This class ONLY handles payments, nothing else.
    public class PaymentProcessor
    {
        // Exp 5: Asynchronous Programming using Async/Await
        public async Task<bool> ProcessPaymentAsync(double amount, Action<string> onNotification)
        {
            Console.WriteLine($"\n[Payment Processor] Contacting bank for ${amount}...");
            
            // Simulating network delay / API call
            await Task.Delay(3000); 

            // Simulating payment success
            bool isSuccess = true; 

            if (isSuccess)
            {
                // Exp 4: Using Delegates for callbacks
                onNotification("Payment successfully received by Bank!");
            }
            return isSuccess;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== E-COMMERCE CONSOLE MODULE ===");
            
            // 1. Initializing OOP Objects (Exp 2)
            Customer cust = new Customer("Aayan Mujawar", "aayan@example.com");
            Order myOrder = new Order(cust, 1500.00); 

            Console.WriteLine($"Processing Order for: {cust.Name}");
            Console.WriteLine($"Subtotal: ${myOrder.Subtotal}");

            // 2. Arithmetic Operation (Exp 1)
            double finalAmount = myOrder.CalculateFinalBill();
            Console.WriteLine($"Total Bill (with 18% Tax): ${finalAmount}");

            // 3. SOLID Principle & Async Simulation (Exp 3 & 5)
            PaymentProcessor processor = new PaymentProcessor();
            
            // 4. Delegates and Lambdas (Exp 4) - We pass an anonymous lambda function as an Action delegate
            bool result = await processor.ProcessPaymentAsync(finalAmount, msg => 
            {
                Console.WriteLine($"\n[Notification] To {cust.Email}: {msg}");
            });

            if (result)
            {
                Console.WriteLine("Order Placed Successfully. Your items will be shipped soon!");
            }

            Console.WriteLine("\n[Console App Execution Complete. Exiting...]");
        }
    }
}
