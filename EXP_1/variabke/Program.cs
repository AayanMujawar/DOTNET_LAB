namespace variable
{
    internal class Program
    {
        static void myMethod()
        {
            Console.WriteLine("Hello");
        }
        static void Main(string[] args)
        {
            myMethod();
            Console.WriteLine("Enter the 2 Numbers : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Arithematic obj=new Arithematic();
            obj.operation(num1, num2);
        }
    }
}
class Arithematic
{
    int add(int num1, int num2)
    {
        return num1 + num2;
    }
    int sub(int num1, int num2)
    {
        return num1 - num2;
    }
    int mul(int num1, int num2)
    {
        return num1 * num2;
    }
    int div(int num1, int num2)
    {
        return num1 / num2;
    }
    public void operation(int num1, int num2)
    {
        Console.WriteLine("Addition of 2 numbers is : " + add(num1, num2));
        Console.WriteLine("Subtraction of 2 numbers is : " + sub(num1, num2));
        Console.WriteLine("Multiplication of 2 numbers is : " + mul(num1, num2));
        Console.WriteLine("Division of 2 numbers is : " + div(num1, num2));
    }

}
