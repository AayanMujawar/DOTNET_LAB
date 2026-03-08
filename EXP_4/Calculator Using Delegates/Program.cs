using System;

class Program
{
    // Declare delegate type
    delegate int Operation(int a, int b);

    // Static methods
    static int Add(int a, int b) { return a + b; }
    static int Sub(int a, int b) { return a - b; }
    static int Mul(int a, int b) { return a * b; }
    static int Div(int a, int b) { return a / b; }

    static void Main(string[] args)
    {
        // Ask user for input
        Console.Write("Enter first number: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int y = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose operation: add / sub / mul / div");
        string choice = Console.ReadLine();

        Operation p;

        // Assign delegate based on user choice
        switch (choice.ToLower())
        {
            case "add":
                p = Add;
                break;
            case "sub":
                p = Sub;
                break;
            case "mul":
                p = Mul;
                break;
            case "div":
                p = Div;
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }

        // Invoke delegate
        int result = p(x, y);
        Console.WriteLine($"Result: {result}");
    }
}