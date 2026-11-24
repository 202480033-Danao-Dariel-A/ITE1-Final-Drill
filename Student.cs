using System;

public class Student
{
    public string StudentNumber { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string Occupation { get; set; }
    public char Gender { get; set; }
    public int CountryCode { get; set; }
    public int AreaCode { get; set; }
    public string PhoneNumber { get; set; }

    public Student(string studentNumber, string surname, string firstName, 
                   string occupation, char gender, int countryCode, 
                   int areaCode, string phoneNumber)
    {
        StudentNumber = studentNumber;
        Surname = surname;
        FirstName = firstName;
        Occupation = occupation;
        Gender = gender;
        CountryCode = countryCode;
        AreaCode = areaCode;
        PhoneNumber = phoneNumber;
    }

    public string GetPronoun()
    {
        return Gender == 'M' ? "His" : "Her";
    }

    public string GetEditDisplayString()
    {
        return $"{FirstName} {Surname} is a {Occupation}. {GetPronoun()} number is {CountryCode}-{AreaCode}-{PhoneNumber}";
    }
}