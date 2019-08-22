using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpByTopics.Async
{
    public class BlockingCodeDemo
    {
        public void Run()
        {
            RunBlocking();

            Console.WriteLine();
            Console.WriteLine("---------------");
            Console.WriteLine();

            RunNonBlocking();
        }

        private void RunBlocking()
        {
            Console.WriteLine("RunBlocking()");

            int result = MultiplyNumbers(150, 5);
            Console.WriteLine($"Result: {result}");

            // Dummy code that always will be run AFTER the previous lines are executed.
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"i: {i}");
            }
        }

        private void RunNonBlocking()
        {
            Console.WriteLine("RunNonBlocking()");

            Task<int> multipliedNumbersTask = MultiplyNumbersAsync(225, 5);

            // Dummy code that will be run while the previous lines are executed.
            int myCounter = 0;
            while (true)
            {
                myCounter++;
                if (multipliedNumbersTask.IsCompleted)
                {
                    break;
                }
            }
            Console.WriteLine($"Number of iterations: {myCounter}");

            Console.WriteLine($"Calculated value: {multipliedNumbersTask.Result}");
        }

        private int MultiplyNumbers(int factor1, int factor2)
        {
            Thread.Sleep(1000);

            return factor1 * factor2;
        }

        private async Task<int> MultiplyNumbersAsync(int factor1, int factor2)
        {
            await Task.Delay(1000);

            return (factor1 * factor2);
        }

    }
}
