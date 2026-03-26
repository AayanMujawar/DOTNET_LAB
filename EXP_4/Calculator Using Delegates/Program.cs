using System;

class Program
{
    // Declare delegate
    delegate int Operation(int a, int b);

    // Methods
    static int Add(int a, int b)
    {
        return a + b;
    }

    static int Sub(int a, int b)
    {
        return a - b;
    }

    static int Mul(int a, int b)
    {
        return a * b;
    }

    static int Div(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
            return 0;
        }
        return a / b;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int y = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose operation: add / sub / mul / div");
        string choice = Console.ReadLine().ToLower();

        Operation p = null;

        switch (choice)
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

        int result = p(x, y);

        Console.WriteLine("Result: " + result);

        Console.ReadLine();
    }
}