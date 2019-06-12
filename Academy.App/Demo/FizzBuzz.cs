using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.App.Demo
{
    public class FizzBuzz
    {
        public void Run()
        {
            //for (int i = 1; i < 101; i++)
            //{
            //    if (i % 3 == 0 && i % 5 == 0)
            //    {
            //        Console.WriteLine("FizzBuzz");
            //    }
            //    else if (i % 3 == 0)
            //    {
            //        Console.WriteLine("Fizz");
            //    }
            //    else if (i % 5 == 0)
            //    {
            //        Console.WriteLine("Buzz");
            //    }
            //    else
            //    {
            //        Console.WriteLine(i.ToString());
            //    }

            //}

            // using System.Linq;
            Enumerable
                .Range(1, 100)
                .ToList()
                .ForEach(a => Console.WriteLine(
                    (a % 3 == 0 && a % 5 == 0) ? "FizzBuzz" :
                        (a % 3 == 0 ? "Fizz" :
                            (a % 5 == 0) ? "Buzz" :
                                a.ToString())));
        }
    }
}
