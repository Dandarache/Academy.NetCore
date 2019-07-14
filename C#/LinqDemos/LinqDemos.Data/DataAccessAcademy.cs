using LinqDemos.Data.Classes;
using System;
using System.Collections.Generic;

namespace LinqDemos.Data
{
    public class DataAccessAcademy
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee("Dan", "Jansson", new DateTime(1972,1,11), GenderType.Male, 150, 140, true),
                new Employee("Lisa", "Andersson", new DateTime(1994,2,1), GenderType.Female, 140, 130, false),
                new Employee("Ulla", "Hedén", new DateTime(1984,2,1), GenderType.Female, 130, 0, false),
                new Employee("Elfrida", "Landén", new DateTime(1974,2,1), GenderType.Female, 131, 130, false),
                new Employee("Gabriel", "Svensson", new DateTime(1993,2,1), GenderType.Male, 132, 130, false),
                new Employee("Hanna", "Nilsson", new DateTime(1990,2,1), GenderType.Female, 133, 140, false),

                new Employee("Albert", "Karlsson", new DateTime(1981,2,1), GenderType.Male, 151, 131, false),
                new Employee("Sven", "Olofsson", new DateTime(1946,2,1), GenderType.Male, 152, 131, false),
                new Employee("Magnus", "Björklund", new DateTime(1981,2,1), GenderType.Male, 153, 131, false),
                new Employee("Martin", "Forsell", new DateTime(1951,2,1), GenderType.Male, 154, 152, true),
                new Employee("Fia", "Pettersson", new DateTime(1992,2,1), GenderType.Female, 155, 152, false),
                new Employee("Kajsa", "Andersson", new DateTime(1989,2,1), GenderType.Female, 156, 131, false),
                new Employee("Eva", "Ekman", new DateTime(1971,2,1), GenderType.Female, 157, 131, false),
                new Employee("Jenny", "Albertsson", new DateTime(1978,2,1), GenderType.Female, 158, 131, true),
                new Employee("Åse", "Wallin", new DateTime(1975,2,1), GenderType.Female, 159, 131, true),
                new Employee("Cecilia", "Johansson", new DateTime(1984,2,1), GenderType.Female, 160, 131, true),
                new Employee("Håkan", "Hellström", new DateTime(2000,2,1), GenderType.Male, 161, 131, false),
                new Employee("Markus", "Magnusson", new DateTime(1977,2,1), GenderType.Male, 162, 131, false),
                new Employee("Elina", "Bengtsson", new DateTime(1956,2,1), GenderType.Female, 163, 131, false),
                new Employee("Adam", "Albrektsson", new DateTime(1999,2,1), GenderType.Male, 164, 131, false),
                new Employee("Emma", "Karlsson", new DateTime(2001,2,1), GenderType.Female, 165, 131, false),
            };
        }
    }
}