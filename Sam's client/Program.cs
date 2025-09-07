// See https://aka.ms/new-console-template for more information
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Client Sam = new Client("Sam", "Reddy", "samhita@gmail.com");
        Client Sam1 = new Client("Sam", "Reddy", "samhita@gmail.com");
        Console.WriteLine(Sam.GetHashCode());
        Console.WriteLine(Sam1.GetHashCode());
        /*Client Sam2=Sam1;
        Console.WriteLine(Sam1);
        Sam2.first_name="Sahi";
        Console.WriteLine(Sam1);
        Console.WriteLine(Sam2);
        Console.WriteLine(Sam2.Equals(Sam1));
        Console.WriteLine(Sam.Equals(Sam1));*/

        HashSet<Client> set = new HashSet<Client>();
        set.Add(Sam);
        set.Add(Sam1);
        foreach (var item in set)
        {
            Console.WriteLine(item);
        }
    }

}
public class Client
{
    //fields
    public string first_name;
    public string last_name;
    public string email;
    public string city;
    public string address;
    public string password;
    //public string confirm_password;
    public Client()
    {

    }
    public Client(string f_name, string l_name, string email_id)
    {
        this.first_name = f_name;
        this.last_name = l_name;
        this.email = email_id;
    }
    public override bool Equals(Object ob1)
    {
        return this.email == ((Client)ob1).email;
    }
    public override int GetHashCode()
    {
        return this.email.GetHashCode();
    }
    public override string? ToString()
    {
        return this.first_name + " " + this.last_name + " " + this.email;
    }

}
