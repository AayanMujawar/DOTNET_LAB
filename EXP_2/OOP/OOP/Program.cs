using System;

internal class Animal
{
    public string name;
    public int age;

    public Animal()
    {
    }

    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public void setAge(int age)
    {
        this.age = age;
    }

    public string getName()
    {
        return name;
    }

    public int getAge()
    {
        return age;
    }
}

internal class Dog : Animal
{
    public Dog(string name, int age) : base(name, age)
    {
    }

    public void bark()
    {
        Console.WriteLine("Barking");
    }
}

class OOP
{
    public static void Main()
    {
        Animal tf = new Dog("Adii", 5);

        Console.WriteLine(tf.getName());
        Console.WriteLine(tf.getAge());

        tf.setAge(12);
        tf.setName("yo");

        Console.WriteLine(tf.getName());
        Console.WriteLine(tf.getAge());

        Dog gg = (Dog)tf;
        gg.bark();

        // Safe casting example
        Animal a = new Animal("xyz", 10);

        if (a is Dog d)
        {
            d.bark();
        }
        else
        {
            Console.WriteLine("Animal is not a Dog");
        }

        Console.ReadLine();
    }
}