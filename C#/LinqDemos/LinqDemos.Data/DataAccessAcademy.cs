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
                new Employee(140, new DateTime(2015, 5, 15), 150, "Dan", "Jansson", "DanJansson", GenderType.Male, new DateTime(1972,1,11), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(130, new DateTime(2015, 5, 15), 140, "Lisa", "Andersson", "LisaAndersson", GenderType.Female, new DateTime(1994,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(0, new DateTime(2015, 5, 15), 130, "Ulla", "Hedén", "UllaHedén", GenderType.Female, new DateTime(1984,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(130, new DateTime(2015, 5, 15), 131, "Elfrida", "Landén", "ElfridaLandén", GenderType.Female, new DateTime(1974,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(130, new DateTime(2015, 5, 15), 132, "Gabriel", "Svensson", "GabrielSvensson", GenderType.Male, new DateTime(1993,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(140, new DateTime(2015, 5, 15), 133, "Hanna", "Nilsson", "HannaNilsson", GenderType.Female, new DateTime(1990,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 151, "Albert", "Karlsson", "AlbertKarlsson", GenderType.Male, new DateTime(1981,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 152, "Sven", "Olofsson", "SvenOlofsson", GenderType.Male, new DateTime(1946,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 153, "Magnus", "Björklund", "MagnusBjörklund", GenderType.Male, new DateTime(1981,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(152, new DateTime(2015, 5, 15), 154, "Martin", "Forsell", "MartinForsell", GenderType.Male, new DateTime(1951,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(152, new DateTime(2015, 5, 15), 155, "Fia", "Pettersson", "FiaPettersson", GenderType.Female, new DateTime(1992,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 156, "Kajsa", "Andersson", "KajsaAndersson", GenderType.Female, new DateTime(1989,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 157, "Eva", "Ekman", "EvaEkman", GenderType.Female, new DateTime(1971,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 158, "Jenny", "Albertsson", "JennyAlbertsson", GenderType.Female, new DateTime(1978,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 159, "Åse", "Wallin", "ÅseWallin", GenderType.Female, new DateTime(1975,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 160, "Cecilia", "Johansson", "CeciliaJohansson", GenderType.Female, new DateTime(1984,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 161, "Håkan", "Hellström", "HåkanHellström", GenderType.Male, new DateTime(2000,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 162, "Markus", "Magnusson", "MarkusMagnusson", GenderType.Male, new DateTime(1977,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 163, "Elina", "Bengtsson", "ElinaBengtsson", GenderType.Female, new DateTime(1956,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 164, "Adam", "Albrektsson", "AdamAlbrektsson", GenderType.Male, new DateTime(1999,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige"),
                new Employee(131, new DateTime(2015, 5, 15), 165, "Emma", "Karlsson", "EmmaKarlsson", GenderType.Female, new DateTime(2001,2,1), "Storgatan 1", "123 45", "Storstaden", "Sverige")
            };
        }
    }
}