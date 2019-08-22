using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpByTopics.Data
{
    public static class EmployeeRepository
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee> {
                new Employee("Dan", "Jansson", 47, new DateTime(1972,1,11), GenderType.Male, 150, 140),
                new Employee("Hanna", "Andersson", 25, new DateTime(1994,2,1), GenderType.Female, 140, 130),
                new Employee("Rebecca", "Hedén", 25, new DateTime(1994,2,1), GenderType.Female, 130, 0),
                new Employee("Malin", "Landén", 25, new DateTime(1994,2,1), GenderType.Female, 131, 130),
                new Employee("Gabriel", "Sauma", 25, new DateTime(1994,2,1), GenderType.Male, 132, 130),
                new Employee("Emma", "Nilsson", 25, new DateTime(1994,2,1), GenderType.Female, 133, 140),

                new Employee("Andreas", "Hebert", 25, new DateTime(1994,2,1), GenderType.Male, 151, 131),
                new Employee("Johan", "Olofsson", 25, new DateTime(1994,2,1), GenderType.Male, 152, 131),
                new Employee("Martin", "Björklund", 25, new DateTime(1994,2,1), GenderType.Male, 153, 131),
                new Employee("Martin", "Mörsell", 25, new DateTime(1994,2,1), GenderType.Male, 154, 152),
                new Employee("Maria", "Bois", 25, new DateTime(1994,2,1), GenderType.Female, 155, 152),
                new Employee("Kajsa", "Norrby", 25, new DateTime(1994,2,1), GenderType.Female, 156, 131),
                new Employee("Olivia", "Lindberg Ekman", 25, new DateTime(1994,2,1), GenderType.Female, 157, 131),
                new Employee("Jenny", "Ahlgren", 25, new DateTime(1994,2,1), GenderType.Female, 158, 131),
                new Employee("Michaela", "Wallin", 25, new DateTime(1994,2,1), GenderType.Female, 159, 131),
                new Employee("Cecilia", "Murphy", 25, new DateTime(1994,2,1), GenderType.Female, 160, 131),
                new Employee("Per", "Hellström", 25, new DateTime(1994,2,1), GenderType.Male, 161, 131),
                new Employee("Marcus", "Gärdeskog Hill", 25, new DateTime(1994,2,1), GenderType.Male, 162, 131),
                new Employee("Lina", "Eriksson", 25, new DateTime(1994,2,1), GenderType.Female, 163, 131),
                new Employee("Adam", "Helsén", 25, new DateTime(1994,2,1), GenderType.Male, 164, 131),
                new Employee("Emma", "Söderström", 25, new DateTime(1994,2,1), GenderType.Female, 165, 131),
            };
        }
    }
}

public enum GenderType
{
    Male = 10,
    Female = 20,
    InterGender = 30,
    Unknown = 40
}

public class Person
{
    // Field variables
    public string FirstName;
    public string LastName;
    public int Age;
    public DateTime Birthdate;
    //public string Gender;
    public GenderType Gender;

    // Constructors
    public Person()
    {

    }
    public Person(string firstName, string lastName, int age, DateTime birthdate, GenderType gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Birthdate = birthdate;
        Gender = gender;
    }

    // Instance methods
    public string FullName()
    {
        string fullName = $"{FirstName} {LastName}";
        return fullName;
    }
}

public class Employee : Person
{
    public int EmployeeId { get; set; }
    public int ManagerId { get; set; }

    public Employee() {}
    public Employee(
        string firstName,
        string lastName,
        int age,
        DateTime birthdate,
        GenderType gender,
        int employeeId,
        int managerId
        ) :
        base(
            firstName,
            lastName,
            age,
            birthdate,
            gender
            )
    {
        EmployeeId = employeeId;
        ManagerId = managerId;
    }
}

