using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class ConsoleTricksDemo
    {
        const string folderPath = @"..\..\..\OutputData\";

        private FileInfo filePath;
        private StreamWriter streamWriter;

        public ConsoleTricksDemo()
        {
            filePath = 
                new FileInfo($"{folderPath}ConsoleOuput{DateTime.Now.ToString("yyyyMMddHHmm")}.txt");
            streamWriter =
                File.CreateText(filePath.FullName);
            streamWriter.AutoFlush = true; 
        }

        ~ConsoleTricksDemo()
        {
            streamWriter.Close();
        }
        public void Run()
        {
            UpdateOutput("Tryck enter utan att mata in text för att avsluta programmet.");
            while (true)
            {
                string result = AskForUserInput("Mata in lite text...");
                if (string.IsNullOrWhiteSpace(result))
                {
                    break;
                }
            }
        }

        private string AskForUserInput(string question)
        {
            UpdateOutput(question);
            string name = Console.ReadLine();
            UpdateOutput(name);
            return name;
        }

        private void UpdateOutput(string message)
        {
            Console.WriteLine(message);

            streamWriter.WriteLine(message);
        }
    }
}
