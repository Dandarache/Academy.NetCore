//using Academy.ConsoleApp.Demo.Classes;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;

namespace Academy.ConsoleApp.Demo
{
    public class FundamentalsDemo1
    {
        Random _instanceRandom = new Random();
        public Random InstanceRandom
        {
            get
            {
                return _instanceRandom;
            }
        }

        static Random staticRandom = new Random();
        public static Random StaticRandom
        {
            get
            {
                return staticRandom;
            }
        }


        public void Run()
        {
            ////////////////////////
            /////// C6 - If Statement
            ////////////////////////


            Console.WriteLine("Min Number");
            string minNumberString = Console.ReadLine();
            int min;
            int.TryParse(minNumberString, out min);

            Console.WriteLine("Max Number");
            string maxNumberString = Console.ReadLine();
            int max;
            int.TryParse(maxNumberString, out max);

            int attempts = 0;
            int maxAnswerAttempts = 6;

            Random random = new Random();
            int randomNumber = random.Next(min, max + 1);

            while (attempts <= maxAnswerAttempts)
            {
                Console.WriteLine($"Guess a number between {min} and {max}");
                string myGuess = Console.ReadLine();
                int guess;
                int.TryParse(myGuess, out guess);

                if (guess == randomNumber)
                {
                    Console.WriteLine("Well done! You guessed the correct number!");
                    HoorayItWorks();
                    break;
                }
                else
                {
                    //Console.WriteLine("The value is " + (guess < randomNumber ? "higher" : "lower"));

                    Console.WriteLine("The value is {0}",
                        guess < randomNumber ? "higher" : "lower");


                    
                    //if (guess < randomNumber)
                    //{
                    //    Console.WriteLine("The value is higher!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("The value is lower!");
                    //}
                    attempts++;
                }
            }

            ////////////////////////
            /////// C5 - ForEach with break
            ////////////////////////


            Console.WriteLine("Mata in en massa bra namn...");
            string myString = Console.ReadLine();

            string[] names = myString.Split(',');

            bool allowZeldaExists = names.Contains("allowZelda");

            //bool allowZeldaExists = false;
            //foreach (var name in names)
            //{
            //    if (name.Equals("allowZelda", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        allowZeldaExists = true;
            //    }
            //}

            foreach (var name in names)
            {
                if (allowZeldaExists)
                {
                    Console.WriteLine($"{name} Andersson");
                }
                else
                {
                    if (name.Equals("zelda", StringComparison.CurrentCultureIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        //continue;
                        Console.WriteLine($"{name} Andersson");
                    }
                }
            }


            //if (name.Contains("zelda") || name.Contains("Zelda") || name.Contains("ZELDA") || name.Contains("zElDa") || name.Contains("zeldA"))
            //else if (name.StartsWith("allow", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    string adjustedName = name.Replace("allow", string.Empty);
            //    Console.WriteLine($"{adjustedName} Andersson");
            //}
            //else if (name.Equals("zelda", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    break;
            //}
            //else
            //{
            //    Console.WriteLine($"{name} Andersson"); 
            //}
            //}




            ////////////////////////
            /////// Data Types - INT
            ////////////////////////

            //Console.WriteLine($"int.MaxValue: {int.MaxValue}");
            //Console.WriteLine($"int.MaxValue: {uint.MaxValue}");


            //// 4294967296;
            //Int32 myValue = -2147483648;


            ////////////////////////
            /////// C4 - ForEach
            ////////////////////////


            //Console.WriteLine("Enter names separated with , (Example: Kalle, Lisa, Sven...)");
            //string names = Console.ReadLine();

            //string[] nameList = names.Split(',');
            //for (int i = 0; i < nameList.Length; i++)
            //{
            //    nameList[i] = nameList[i].Trim().PadRight(40, '-').ToUpper();
            //}

            //Array.Sort(nameList);
            //Array.Reverse(nameList);

            //int counter = 1;

            //foreach (var name in nameList)
            //{
            //    if (name?.Trim().Length < 2)
            //    {
            //        Console.WriteLine($"The name \"{name}\" is to short!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"[{counter}] {name} Andersson");
            //    }
            //    counter++;
            //}

            ////////////////////////
            /////// C3 - For
            ////////////////////////

            //Console.WriteLine("What is your name?");
            //string name = Console.ReadLine();

            //Console.WriteLine("How many rows (iterations)?");
            //int rows;
            //int.TryParse(Console.ReadLine(), out rows);

            //Console.WriteLine("How many columns (iterations)?");
            //int columns;
            //int.TryParse(Console.ReadLine(), out columns);

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int u = 0; u < columns; u++)
            //    {
            //        Console.Write(name + "\t");
            //    }
            //    Console.WriteLine();
            //}

            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int u = 0; u < columns; u++)
            //    {
            //        sb.AppendFormat("{0}\t", name);
            //    }
            //    sb.AppendLine();
            //}

            //File.WriteAllText(@"c:\temp\c3.txt", sb.ToString());


            //////////////////////
            ///// Static vs Instance
            //////////////////////


            //Person person1 = new Person("Dan", "Jansson", 47, new DateTime(1972, 1, 11));
            //person1.UpdateLastName("Hansson");

            ////Person.UpdateLastName


            //int foo = 1;



            //Program program = new Program();
            //Random myInstanceRandom = program.InstanceRandom;

            //Random myStaticRandom = Program.StaticRandom;


            //////////////////////
            ///// C1 - If
            //////////////////////

            //DateTime bedtime;
            //DateTime wokeUp;

            //while (true)
            //{
            //    //Random myRandom = Program.StaticRandom;
            //    //int myRandomInt = myRandom.Next();


            //    Console.WriteLine("When did you go to bed (Example: 2019-06-03 22:00)?");
            //    string bedtimeString = Console.ReadLine();
            //    DateTime.TryParse(bedtimeString, out bedtime);

            //    if (bedtime == DateTime.MinValue)
            //    {
            //        Console.WriteLine("Please enter valid bedtime!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Bedtime: {bedtime.ToLongDateString()}");
            //        Console.WriteLine($"Bedtime: {bedtime.ToLongTimeString()}");
            //        Console.WriteLine($"Bedtime: {bedtime.ToUniversalTime()}");
            //        Console.WriteLine($"Bedtime: {bedtime.ToString("m", new CultureInfo("de"))}");
            //        Console.WriteLine($"Bedtime: {bedtime.ToString("d", new CultureInfo("en-US"))}");
            //        Console.WriteLine($"Bedtime: {bedtime.ToString("d", new CultureInfo("sv-SE"))}");
            //        Console.WriteLine($"Bedtime: {bedtime.ToString("MM yyyy DD hh mm")}");
            //        break;
            //    }

            //}

            //while (true)
            //{
            //    Console.WriteLine("When did you wake up (Example: 2019-06-03 22:00)?");
            //    string wokeUpString = Console.ReadLine();
            //    DateTime.TryParse(wokeUpString, out wokeUp);

            //    if (wokeUp == DateTime.MinValue)
            //    {
            //        Console.WriteLine("Please enter time when you woke up!");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Woke up: {wokeUp}");
            //        break;
            //    }
            //}

            //int sleepHours = wokeUp.Subtract(bedtime).Hours;

            //Console.WriteLine($"You've slept for {sleepHours} hours");

            //Console.ReadLine();



            ////{
            //while (true)
            //{
            //    Console.WriteLine("What is your age?");
            //    string ageString = Console.ReadLine();
            //    int.TryParse(ageString, out int age);

            //    if (age == 0)
            //    {
            //        Console.WriteLine("Please enter a valid age!");
            //    }
            //    else if (age == 47)
            //    {
            //        Console.WriteLine($"Tjena Dan du är {age} år.");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Your age is: {age}");
            //        break;
            //    }
            //}

            //Console.ReadLine();
            ////}



            ////////////////////
            /// F3 - String Concatenation
            ////////////////////

            //Console.WriteLine("Enter fruit 1:");
            //string fruit1 = Console.ReadLine();
            //fruit1 = fruit1.Trim().ToUpper();

            //Console.WriteLine("Enter fruit 2:");
            //string fruit2 = Console.ReadLine();
            //fruit2 = fruit2.Trim().ToUpper();

            //Console.WriteLine("Enter fruit 3:");
            //string fruit3 = Console.ReadLine();
            //fruit3 = fruit3.Trim().ToUpper();

            //string message1 = 
            //    "Fruits entered: " + fruit1 + ", " + fruit2 + ", " + fruit3;

            //string message2 = 
            //    string.Format("Fruits entered: {0}, {1}, {2}", fruit1, fruit2, fruit3);

            //string message3 = 
            //    $"Fruits entered: {fruit1}, {fruit2}, {fruit3}";

            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.AppendLine("Fruits entered: " + fruit1 + ", " + fruit2 + ", " + fruit3);
            //stringBuilder.AppendFormat("Fruits entered: {0}, {1}, {2}", fruit1, fruit2, fruit3);
            //stringBuilder.AppendLine($"Fruits entered: {fruit1}, {fruit2}, {fruit3}");
            //Console.WriteLine(stringBuilder.ToString());

            //Console.WriteLine(message1);



            //Console.ReadLine();


            ////////////////////
            /// 2 - Types
            ////////////////////

            //Console.WriteLine("What is your name?");
            //string name = Console.ReadLine();

            //Console.WriteLine("How old are you?");
            ////int age = int.Parse(Console.ReadLine());
            //int age;
            //int.TryParse(Console.ReadLine(), out age);

            //Console.WriteLine("What is your favorite character?");
            //char favoriteCharacter = char.Parse(Console.ReadLine());

            //// String concatenation
            //string message1 = "Your name is: " + name;
            ////Console.WriteLine(message1);

            //// Placeholders
            //string message2 = 
            //    string.Format(
            //        "Your name is: {0} {1}", 
            //        name,
            //        name);
            ////Console.WriteLine(message2);

            //string message3 = $"Your name is: {name}";
            //Console.WriteLine(message3);

            ////Console.WriteLine("Your name is: " + name);
            //Console.WriteLine("Your age is:" + age);
            //Console.WriteLine("IsNumeric? " + char.IsNumber(favoriteCharacter));

            //Console.Beep(1000, 100);
            //Console.Beep(2000, 100);
            //Console.Beep(4000, 500);


            //Console.ReadLine();

            ////////////////////
            /// Rainbow
            ////////////////////
            //Console.WriteLine("Enter your name");
            //string name = Console.ReadLine();

            //ConsoleColor[] colors = new ConsoleColor[5];
            //colors[0] = ConsoleColor.Blue;
            //colors[1] = ConsoleColor.Cyan;
            //colors[2] = ConsoleColor.Yellow;
            //colors[3] = ConsoleColor.Red;
            //colors[4] = ConsoleColor.Green;

            //Console.Write("Your name is: ");
            //int colorIndex = 0;
            //foreach (var letter in name.ToCharArray())
            //{
            //    Console.Write(letter);
            //    colorIndex++;
            //    if (colorIndex == 5)
            //    {
            //        colorIndex = 0;
            //    }
            //    Console.ForegroundColor = colors[colorIndex];
            //}
            //Console.ReadLine();


            ////////////////////
            /// 1 - Intro
            ////////////////////

            //if (args.Length > 0)
            //{
            //    if (args[0] == "/?")
            //    {
            //        Console.WriteLine("So you have a question...");
            //        Console.WriteLine("Here is all the help information.");
            //    }
            //    else
            //    {
            //        foreach (var vadSomHelst in args)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Yellow;
            //            Console.BackgroundColor = ConsoleColor.Red;
            //            Console.WriteLine("Hello " + vadSomHelst + "!");
            //        }
            //    }
            //}

            //Console.WriteLine("Press any key...");
            //var myInt = Console.Read();
            //Console.WriteLine($"The UNICODE character is: {myInt}");
            //Console.ReadLine();

            //Console.WriteLine("Write any string...");
            //var myString = Console.ReadLine();
            //Console.WriteLine("The string entered was: " + myString);
            //Console.ReadLine();

            //var myConsoleKey = Console.ReadKey();
            //Console.WriteLine(myConsoleKey);
        }

        private static void HoorayItWorks()
        {
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
        }
    }
}
