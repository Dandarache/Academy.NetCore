using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.App.Demo
{
    class CollectionsListDemo
    {
        public void Run()
        {
            Console.WriteLine("Mata in ett antal namn separerat med mellanslag.");


            ////////////////
            // DEMO 3 - List<T>
            ////////////////

            // Skapa listan utanför loopen

            //while (1 == 1)
            //{
            //    string name = Console.ReadLine();
                
                  // Om namnet = "quit" skall break anropas...
                  // Annars:
                  //  Lägg till namnet i listan...

            //}

            // Presentera namnen


            ////////////////
            // DEMO 2 - List<T>
            ////////////////
            string[] myArray = Console.ReadLine().Split(' ');
            //List<string> myList = new List<string>(myArray);
            List<string> myList = new List<string>();
            myList.AddRange(myArray);
            //myList.AddRange(myArray);
            //myList.AddRange(myArray);
            //myList.AddRange(myArray);
            //myList.AddRange(myArray);
            //myList.AddRange(myArray);
            //myList.AddRange(myArray);
            //myList.AddRange(myArray);
            //myList.AddRange(myArray);

            //myList.Remove("Kalle");

            myList.RemoveAll(a => a.Contains("an"));

            //Console.WriteLine(myList[2]);


            foreach (var listItem in myList)
            {
                Console.WriteLine($"Namn: {listItem}");
            }

            ////////////////
            // DEMO 1 - ARRAY
            ////////////////

            //string[] myArray = Console.ReadLine().Split(' ');
            //foreach (var arrayItem in myArray)
            //{
            //    Console.WriteLine($"Namn: {arrayItem}");
            //}
        }
    }
}
