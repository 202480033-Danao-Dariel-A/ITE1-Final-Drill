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
                    EditEntry();
                    break;
                case "3":
                    SearchEntry();
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
            
            char gender = 'M';
            bool validGender = false;
            while (!validGender)
            {
                Console.Write("Enter gender (M for male, F for female): ");
                string genderInput = Console.ReadLine().ToUpper();
                if (genderInput == "M" || genderInput == "F") { gender = genderInput[0]; validGender = true; }
                else { Console.WriteLine("  [Error] Please enter M or F."); }
            }

            int countryCode = 0;
            bool validCountry = false;
            while (!validCountry)
            {
                Console.Write("Enter country code: ");
                string ccInput = Console.ReadLine();
                
                if (int.TryParse(ccInput, out countryCode))
                {
                    if (countryCode == 60 || countryCode == 62 || countryCode == 63 || countryCode == 65 || countryCode == 66) { validCountry = true; }
                    else { Console.WriteLine("  [Error] Invalid country code. Please use 60, 62, 63, 65, or 66."); }
                }
                else { Console.WriteLine("  [Error] Please enter a valid number."); }
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
            
            if (answer != "Y") { addAnother = false; }
        }
    }

    // --- PHASE 3: EDIT ENTRY ---
    public static void EditEntry()
    {
        Console.Write("\nEnter student number: ");
        string searchId = Console.ReadLine();

        // 1. Find the student in the list
        Student studentToEdit = null;
        foreach (Student s in phonebook)
        {
            if (s.StudentNumber == searchId)
            {
                studentToEdit = s;
                break;
            }
        }

        // 2. If not found, alert error
        if (studentToEdit == null)
        {
            Console.WriteLine("  [Error] Student number not found.");
            return;
        }

        // 3. If found, enter the edit loop
        bool editing = true;
        while (editing)
        {
            Console.WriteLine($"\nHere is the existing information about {studentToEdit.StudentNumber}:");
            
            // Uses the method we wrote in Student.cs
            Console.WriteLine(studentToEdit.GetEditDisplayString());

            Console.WriteLine("\nWhich of the following information do you wish to change?");
            Console.WriteLine("[1] Student number [2] Surname [3] Gender [4] Occupation");
            Console.WriteLine("[5] Country code [6] Area code [7] Phone number");
            Console.WriteLine("[8] None - Go back to main menu");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new student number: ");
                    studentToEdit.StudentNumber = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Enter new surname: ");
                    studentToEdit.Surname = Console.ReadLine();
                    break;
                case "3":
                    bool validGender = false;
                    while (!validGender)
                    {
                        Console.Write("Enter new gender (M/F): ");
                        string g = Console.ReadLine().ToUpper();
                        if (g == "M" || g == "F") { studentToEdit.Gender = g[0]; validGender = true; }
                        else { Console.WriteLine("  [Error] Please enter M or F."); }
                    }
                    break;
                case "4":
                    Console.Write("Enter new occupation: ");
                    studentToEdit.Occupation = Console.ReadLine();
                    break;
                case "5":
                    // Validation for changing country code
                    int cc = 0;
                    bool validCountry = false;
                    while (!validCountry)
                    {
                        Console.Write("Enter new country code: ");
                        string ccInput = Console.ReadLine();
                        if (int.TryParse(ccInput, out cc))
                        {
                            if (cc == 60 || cc == 62 || cc == 63 || cc == 65 || cc == 66) { validCountry = true; }
                            else { Console.WriteLine("  [Error] Invalid country code."); }
                        }
                        else { Console.WriteLine("  [Error] Enter a number."); }
                    }
                    studentToEdit.CountryCode = cc;
                    break;
                case "6":
                    Console.Write("Enter new area code: ");
                    studentToEdit.AreaCode = int.Parse(Console.ReadLine());
                    break;
                case "7":
                    Console.Write("Enter new phone number: ");
                    studentToEdit.PhoneNumber = Console.ReadLine();
                    break;
                case "8":
                    editing = false; // Exits the loop and goes back to Main
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

        // --- PHASE 4: SEARCH ENTRY ---
    public static void SearchEntry()
    {
        List<int> selectedCodes = new List<int>();
        bool selecting = true;
        int choiceNum = 1;

        Console.WriteLine("\nFrom which country:");
        Console.WriteLine("[1] Philippines [2] Thailand [3] Singapore [4] Indonesia");
        Console.WriteLine("[5] Malaysia [6] ALL [0] No More");

        while (selecting)
        {
            Console.Write($"Enter choice {choiceNum}: ");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1": selectedCodes.Add(63); choiceNum++; break;
                case "2": selectedCodes.Add(66); choiceNum++; break;
                case "3": selectedCodes.Add(65); choiceNum++; break;
                case "4": selectedCodes.Add(62); choiceNum++; break;
                case "5": selectedCodes.Add(60); choiceNum++; break;
                case "6": 
                    selectedCodes.Clear();
                    selectedCodes.AddRange(new int[] { 60, 62, 63, 65, 66 });
                    selecting = false; 
                    break;
                case "0": selecting = false; break;
                default: Console.WriteLine("  [Error] Invalid choice."); break;
            }
        }

        List<Student> filteredList = new List<Student>();
        foreach (Student s in phonebook)
        {
            if (selectedCodes.Contains(s.CountryCode))
            {
                filteredList.Add(s);
            }
        }

        filteredList.Sort((x, y) => string.Compare(x.Surname, y.Surname));

        Console.WriteLine();
        if (filteredList.Count == 0)
        {
            Console.WriteLine("No students found from the selected countries.");
            return;
        }

        foreach (Student s in filteredList)
        {
            string lowerOcc = s.Occupation.ToLower();
            Console.WriteLine($"{s.Surname}, {s.FirstName}, with student number {s.StudentNumber}, is a {lowerOcc}. {s.GetPronoun()} phone number is {s.CountryCode}-{s.AreaCode}-{s.PhoneNumber}");
        }
    }
}