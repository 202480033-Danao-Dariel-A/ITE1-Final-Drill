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
                    StoreEntry();
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

    public static void StoreEntry()
    {
        bool addAnother = true;

        while (addAnother)
        {
            Console.WriteLine("\n--- Enter New Student Information ---");
            
            Console.Write("Enter student number: ");
            string studentNumber = Console.ReadLine();
            
            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();
            
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            
            Console.Write("Enter occupation: ");
            string occupation = Console.ReadLine();
            
            // Safety check for gender input
            char gender = 'M';
            bool validGender = false;
            while (!validGender)
            {
                Console.Write("Enter gender (M for male, F for female): ");
                string genderInput = Console.ReadLine().ToUpper();
                if (genderInput == "M" || genderInput == "F")
                {
                    gender = genderInput[0];
                    validGender = true;
                }
                else
                {
                    Console.WriteLine("  [Error] Please enter M or F.");
                }
            }

            // Country Code Validation Loop
            int countryCode = 0;
            bool validCountry = false;
            while (!validCountry)
            {
                Console.Write("Enter country code: ");
                string ccInput = Console.ReadLine();
                
                if (int.TryParse(ccInput, out countryCode))
                {
                    if (countryCode == 60 || countryCode == 62 || countryCode == 63 || countryCode == 65 || countryCode == 66)
                    {
                        validCountry = true;
                    }
                    else
                    {
                        Console.WriteLine("  [Error] Invalid country code. Please use 60, 62, 63, 65, or 66.");
                    }
                }
                else
                {
                    Console.WriteLine("  [Error] Please enter a valid number.");
                }
            }

            Console.Write("Enter area code: ");
            int areaCode = int.Parse(Console.ReadLine());
            
            Console.Write("Enter number: ");
            string phoneNumber = Console.ReadLine();


            Student newStudent = new Student(studentNumber, surname, firstName, occupation, gender, countryCode, areaCode, phoneNumber);
            phonebook.Add(newStudent);
            
            Console.WriteLine("Entry saved successfully!");

            Console.Write("Do you want to enter another entry [Y/N]? ");
            string answer = Console.ReadLine().ToUpper();
            
            if (answer != "Y")
            {
                addAnother = false;
            }
        }
    }
}