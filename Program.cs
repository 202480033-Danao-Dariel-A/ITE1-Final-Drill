using System;
using System.Collections.Generic;

public class Program
{
    public static List<Student> phonebook = new List<Student>();

    public static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country");
            Console.WriteLine("[4] Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("--> [Store Feature] to be implemented.");
                    break;
                case "2":
                    Console.WriteLine("--> [Edit Feature] to be implemented.");
                    break;
                case "3":
                    Console.WriteLine("--> [Search Feature] to be implemented.");
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}