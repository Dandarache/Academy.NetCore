using EfSamurai.Test.Classes;
using System;
using System.Collections.Generic;

namespace EfSamurai.Test
{
    public class DataAccessAcademy
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee("Dan", "Jansson", new DateTime(1972,1,11), GenderType.Male, 150, 140, true),
                new Employee("Hanna", "Andersson", new DateTime(1994,2,1), GenderType.Female, 140, 130, false),
                new Employee("Rebecca", "Hedén", new DateTime(1984,2,1), GenderType.Female, 130, 0, false),
                new Employee("Malin", "Landén", new DateTime(1974,2,1), GenderType.Female, 131, 130, false),
                new Employee("Gabriel", "Sauma", new DateTime(1993,2,1), GenderType.Male, 132, 130, false),
                new Employee("Emma", "Nilsson", new DateTime(1990,2,1), GenderType.Female, 133, 140, false),

                new Employee("Andreas", "Hebert", new DateTime(1981,2,1), GenderType.Male, 151, 131, false),
                new Employee("Johan", "Olofsson", new DateTime(1973,2,1), GenderType.Male, 152, 131, false),
                new Employee("Martin", "Björklund", new DateTime(1981,2,1), GenderType.Male, 153, 131, false),
                new Employee("Martin", "Mörsell", new DateTime(1951,2,1), GenderType.Male, 154, 152, true),
                new Employee("Maria", "Bois", new DateTime(1992,2,1), GenderType.Female, 155, 152, false),
                new Employee("Kajsa", "Norrby", new DateTime(1989,2,1), GenderType.Female, 156, 131, false),
                new Employee("Olivia", "Lindberg Ekman", new DateTime(1971,2,1), GenderType.Female, 157, 131, false),
                new Employee("Jenny", "Ahlgren", new DateTime(1978,2,1), GenderType.Female, 158, 131, true),
                new Employee("Michaela", "Wallin", new DateTime(1975,2,1), GenderType.Female, 159, 131, true),
                new Employee("Cecilia", "Murphy", new DateTime(1984,2,1), GenderType.Female, 160, 131, true),
                new Employee("Per", "Hellström", new DateTime(2000,2,1), GenderType.Male, 161, 131, false),
                new Employee("Marcus", "Gärdeskog Hill", new DateTime(1977,2,1), GenderType.Male, 162, 131, false),
                new Employee("Lina", "Eriksson", new DateTime(1956,2,1), GenderType.Female, 163, 131, false),
                new Employee("Adam", "Helsén", new DateTime(1999,2,1), GenderType.Male, 164, 131, false),
                new Employee("Emma", "Söderström", new DateTime(2001,2,1), GenderType.Female, 165, 131, false),
            };
        }
    }
}