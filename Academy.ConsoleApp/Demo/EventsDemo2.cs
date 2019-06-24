using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class EventsDemo2
    {
        delegate void MyDelegate();
        event MyDelegate SpacePressed;

        public void Run()
        {
            SpacePressed += SetBackgroundColor;
            SpacePressed += SetForegroundColor;
            SpacePressed += MyWriteLine;
            SpacePressed += SoonItIsLunchTime;

            Console.WriteLine();
            Console.WriteLine("Press SPACE to invoke methods. Press 'Q' to quit");
            Console.WriteLine();

            ListenToKeyPress();
        }

        private void SetBackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        private void SetForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private void MyWriteLine()
        {
            Console.WriteLine("------------------");
        }

        public void SoonItIsLunchTime()
        {
            Console.WriteLine("Snart är det lunch!");
        }

        private void ListenToKeyPress()
        {
            char keyPressed;
            do
            {
                keyPressed = Console.ReadKey(true).KeyChar;
                if (keyPressed == ' ')
                {
                    SpacePressed();
                }
            }
            while (keyPressed != 'q');
        }

    }
}
