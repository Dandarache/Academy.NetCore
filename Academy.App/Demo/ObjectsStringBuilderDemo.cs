using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Academy.App.Demo
{
    public class ObjectsStringBuilderDemo
    {
        public void Run()
        {
            int[] cycles = new int[5];
            cycles[0] = 5;
            cycles[1] = 50;
            cycles[2] = 500;
            cycles[3] = 5000;
            cycles[4] = 50000;

            Console.WriteLine("Enter test phrase:");
            string inputString = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Test phrase: {inputString}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            long totalMillisecondsString = StringTest(inputString, cycles);
            Console.WriteLine($"totalMillisecondsString: {totalMillisecondsString}");

            Console.WriteLine();

            long totalMillisecondsStringBuilder = StringBuilderTest(inputString, cycles);
            Console.WriteLine($"totalMillisecondsStringBuilder: {totalMillisecondsStringBuilder}");
        }

        private long StringBuilderTest(string inputString, int[] cycles)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("STRINGBUILDER TEST");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.WriteLine($"Cycles\t\t\t\tLength of string\t\tTime\t\tTotal Time");

            Stopwatch stopwatchTotal = new Stopwatch();
            stopwatchTotal.Start();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var cycle in cycles)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string resultString = GenerateStringStringBuilder(inputString, cycle);
                stopwatch.Stop();

                TimeSpan elapsedTime = stopwatch.Elapsed;

                Console.WriteLine($"{cycle}\t\t\t\t{resultString.Length}\t\t\t\t{elapsedTime.TotalMilliseconds}\t\t{stopwatchTotal.Elapsed.TotalMilliseconds}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            stopwatchTotal.Stop();
            return stopwatchTotal.ElapsedMilliseconds;
        }

        private long StringTest(string inputString, int[] cycles)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("STRING TEST");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            Console.WriteLine($"Cycles\t\t\t\tLength of string\t\tTime\t\tTotal Time");

            Stopwatch stopwatchTotal = new Stopwatch();
            stopwatchTotal.Start();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var cycle in cycles)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string resultString = GenerateString(inputString, cycle);
                stopwatch.Stop();

                TimeSpan elapsedTime = stopwatch.Elapsed;

                Console.WriteLine($"{cycle}\t\t\t\t{resultString.Length}\t\t\t\t{elapsedTime.TotalMilliseconds}\t\t{stopwatchTotal.Elapsed.TotalMilliseconds}");
            }
            Console.ForegroundColor = ConsoleColor.White;

            stopwatchTotal.Stop();
            return stopwatchTotal.ElapsedMilliseconds;
        }


        private string GenerateStringStringBuilder(string repeatme, int cycles)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < cycles; i++)
            {
                stringBuilder.Append(repeatme);
            }
            return stringBuilder.ToString();
        }

        private string GenerateString(string repeatme, int cycles)
        {
            string result = string.Empty;
            for (int i = 0; i < cycles; i++)
            {
                result = result + repeatme;
            }
            return result;
        }
    }
}
