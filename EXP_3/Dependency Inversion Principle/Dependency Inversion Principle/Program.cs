using System;

// Abstraction
public interface IMessage
{
    void SendMessage();
}

// Concrete class 1
public class EmailMessage : IMessage
{
    public void SendMessage()
    {
        Console.WriteLine("Email sent");
    }
}

// Concrete class 2
public class SmsMessage : IMessage
{
    public void SendMessage()
    {
        Console.WriteLine("SMS sent");
    }
}

// High-level module depending on abstraction
public class Notification
{
    private readonly IMessage message;

    public Notification(IMessage message)
    {
        this.message = message;
    }

    public void Notify()
    {
        message.SendMessage();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Send Email
        IMessage email = new EmailMessage();
        Notification n1 = new Notification(email);
        n1.Notify();

        // Send SMS
        IMessage sms = new SmsMessage();
        Notification n2 = new Notification(sms);
        n2.Notify();

        Console.ReadLine();
    }
}