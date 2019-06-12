using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.App.Demo
{
    public class MethodsDemo2
    {
        public void Run()
        {
            TimeSpan workStart = GetTimeValue("When do start working in the morning?");
            //Console.Write("When do you go for lunch? ");
            //string lunchStartString = Console.ReadLine();
            //TimeSpan lunchStart = TimeSpan.Parse(lunchStartString);

            TimeSpan lunchStart = GetTimeValue("When do you go for lunch?");

            TimeSpan lunchEnd = GetTimeValue("When does your lunch end?");

            TimeSpan workEnd = GetTimeValue("When do you go home from work?");

            TimeSpan workTime = (lunchStart - workStart) + (workEnd - lunchEnd);
            Console.WriteLine($"You have worked {workTime.Hours}h and {workTime.Minutes} minutes");
        }

        private static TimeSpan GetTimeValue(string question)
        {
            while (true)
            {
                Console.WriteLine(question);
                string timeString = Console.ReadLine();
                bool success = 
                    TimeSpan.TryParse(timeString, out TimeSpan timeSpan);
                if (success)
                {
                    return timeSpan;
                }

                //TimeSpan workStart = TimeSpan.Parse(workStartString);
            }
        }
    }
}
