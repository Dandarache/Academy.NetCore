using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace ConsoleApp1.Demo
{
    public class LinqDemo
    {
        public void Run()
        {
            string fileContents = GetFileContents();

            //string[] rows = fileContents.Split("\r\n");
            //foreach (var item in rows)
            //{
            //    Console.WriteLine($"Data: '{item}'");
            //}

            //////////////////
            // Demo 1
            //////////////////
            //var tvShows = fileContents.Split("\r\n")
            //    .Select(a => a);
            //foreach (var item in tvShows)
            //{
            //    Console.WriteLine($"Data: '{item}'");
            //}

            //////////////////
            // Demo 2
            //////////////////
            //var tvShows = fileContents.Split("\r\n")
            //    .Select(a => a.Split('*'));
            //foreach (var item in tvShows)
            //{
            //    var currentItem = item;
            //    Console.WriteLine($"Data: '{item[0]}', '{item[1]}', '{item[2]}'");
            //}

            //////////////////
            // Demo 3
            //////////////////
            var tvShows = fileContents.Split("\r\n")
                .Select(a => a.Split('*'))
                .Where(b => b.First().Equals("SVT1"));
            foreach (var item in tvShows)
            {
                var currentItem = item;
                Console.WriteLine($"Data: '{item[0]}', '{item[1]}', '{item[2]}'");
            }
        }

        private string GetFileContents()
        {
            return File.ReadAllText(@"C:\Users\danja\source\repos\Academy\ConsoleApp1\ExternalData\tv-data.txt");
        }
    }
}
