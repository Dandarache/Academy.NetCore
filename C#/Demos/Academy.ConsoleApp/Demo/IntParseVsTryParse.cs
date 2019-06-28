

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class IntParseVsTryParse
    {
        public void Run()
        {
            int cycles = 5-000-000-000;
            List<string> words = new List<string>();
            words.Add("Dan");
            words.Add("3");
            words.Add("Kalle");
            words.Add("Asdfgh");
            words.Add("55");
            words.Add("Hugo");
            words.Add("Lisa");
            words.Add("Urban");
            words.Add("13");
            words.Add("99");

            Random random = new Random();

            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Parse 5 000 000 words using int.Parse()");
            stopwatch.Start();
            for (int i = 0; i < cycles; i++)
            {
                string currentWord = words[random.Next(0, words.Count)];
                int parsedInt;
                try
                {
                    parsedInt = int.Parse(currentWord);
                }
                catch { }
            }
            stopwatch.Stop();
            Console.WriteLine($"int.Parse execution time: {stopwatch.Elapsed}");

            stopwatch.Reset();

            Console.WriteLine("Parse 5 000 000 words using int.TryParse()");
            stopwatch.Start();
            for (int i = 0; i < cycles; i++)
            {
                string currentWord = words[random.Next(0, words.Count)];
                int.TryParse(currentWord, out int parsedInt);
            }
            stopwatch.Stop();
            Console.WriteLine($"int.TryParse execution time: {stopwatch.Elapsed}");
        }
    }
}
