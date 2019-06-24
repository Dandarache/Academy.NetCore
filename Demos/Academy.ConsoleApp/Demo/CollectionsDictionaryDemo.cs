using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class CollectionsDictionaryDemo
    {
        public void Run()
        {
            // Samla in värden från användaren.
            Dictionary<int, string> products = BuildProductDictionary();

            // Lista alla produkter.
            DisplayProductDictionary(products);

            // Skapa en textfil med alla produkter.
            DumpProductsToTextFile(products);
        }

        private void DumpProductsToTextFile(Dictionary<int, string> products)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<int, string> item in products)
            {
                sb.AppendLine($"Product ID: {item.Key}, Product Name: {item.Value}");
            }

            System.IO.File.WriteAllText(
                @"c:\Temp\Academy\dictionarydump.txt", 
                sb.ToString());
        }

        private Dictionary<int, string> BuildProductDictionary()
        {
            Dictionary<int, string> products =
                new Dictionary<int, string>();

            while (true)
            {
                Console.WriteLine("Ange en produkt enligt \"3,Produktnamn\"");
                string productData = Console.ReadLine(); // 8,Shoes

                if (productData.Equals(string.Empty))
                {
                    break;
                }

                string[] productArray = productData.Split(',');
                if (productArray.Length != 2)
                {
                    Console.WriteLine("Du måste ange en giltig produkt enligt \"3,Produktnamn\"");
                    continue;
                }

                int.TryParse(productArray[0], out int productId);
                string product = productArray[1];

                if (productId.Equals(0))
                {
                    Console.WriteLine("Du måste ange en giltig produkt enligt \"3,Produktnamn\"");
                    continue;
                }

                if (!products.ContainsKey(productId))
                {
                    products.Add(productId, product);
                }
                else
                {
                    Console.WriteLine("Det finns redan en produkt med samma produkt ID.");
                }
            }

            return products;

        }

        // Nedan är metod-signaturen för att skriva ut alla produkter.
        // void DisplayProductDictionary(Dictionary<int, string> products);

        private void DisplayProductDictionary(Dictionary<int, string> products)
        {
            foreach (KeyValuePair<int, string> item in products)
            {
                Console.WriteLine($"Product ID: {item.Key}, Product Name: {item.Value}");
            }
        }

    }
}
