using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo
{
    class Program
    {
        private static readonly DataAccess _dataAccess = new DataAccess();

        static void Main(string[] args)
        {
            _dataAccess.ClearAndInitDatabase();
            Console.WriteLine();

            DisplayAllFruits();
            Console.WriteLine();

            DisplayAllFruitsBasedOnCategory("Kärnfrukt");
        }

        private static void DisplayAllFruits()
        {
            List<Fruit> fruits = 
                _dataAccess.GetAllFruits();

            foreach (var fruit in fruits)
            {
                Console.WriteLine($"{fruit.Id}\t{fruit.Name}\t{fruit.Price}\t{fruit.Color.Name}\t{fruit.Category.Name}");
            }
        }

        private static void DisplayAllFruitsBasedOnCategory(string categoryString)
        {
            List<Fruit> fruitsInCategory = 
                _dataAccess.GetAllFruitsBasedOnCategory(categoryString);

            foreach (var fruit in fruitsInCategory)
            {
                Console.WriteLine($"{fruit.Id}\t{fruit.Name}\t{fruit.Price}\t{fruit.Color.Name}\t{fruit.Category.Name}");
            }
        }
    }
}
