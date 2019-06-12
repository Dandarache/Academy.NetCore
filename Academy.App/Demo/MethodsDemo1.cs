using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.App.Demo
{
    class MethodsDemo1
    {
        public void Run()
        {
            //Console.Write("When do start working in the morning? ");
            //Console.Write("When do you go for lunch? ");
            //Console.Write("When does your lunch end? ");
            //Console.Write("When do you go home from work? ");
            //Console.WriteLine($"You have worked {worktime.Hours}h and {worktime.Minutes} minutes");

            // Ask the current user for his or her name based on busniess rules...
            string name = AskForUserInput("What is your name?");

            //string name = GetName();

            //Program3 myProgram = new Program3();
            //string name = myProgram.GetName();

            //Console.WriteLine("What is your name?");
            //string name = Console.ReadLine();

            //////////////////////////////////////////

            string ageString = AskForUserInput("How old are you?");

            //string question = "How old are you?";
            //string ageString = AskForUserInput(question);
            int age;
            int.TryParse(ageString, out age);

            //Console.WriteLine("How old are you?");
            //string ageString = Console.ReadLine();
            //int age;
            //int.TryParse(ageString, out age);

            //////////////////////////////////////////

            string[] hobbies = AskForUserInputReturnArray("Name some of your hobbies separated by comma:");

            //Console.WriteLine("Name some of your hobbies separated by comma:");
            //string myHobbies = Console.ReadLine();
            //string[] hobbies = myHobbies.Split(',');

            string[] favoriteMovies = AskForUserInputReturnArray("Name some of your favorite movies separated by comma:");

            //Console.WriteLine("Name some of your favorite movies separated by comma:");
            //string myFavoriteMovies = Console.ReadLine();
            //string[] favoriteMovies = myFavoriteMovies.Split(',');
        }

        public string[] AskForUserInputReturnArray(string question)
        {
            Console.WriteLine(question);
            string inputString = Console.ReadLine();
            string[] returnValues = inputString.Split(',');
            return returnValues;
        }

        public string AskForUserInput(string question)
        {
            Console.WriteLine(question);
            string name = Console.ReadLine();
            return name;
        }


        public string GetName()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            return name;
        }

        //public string GetName()
        //{
        //    Console.WriteLine("What is your name?");
        //    string name = Console.ReadLine();
        //    return name;
        //}
    }
}
