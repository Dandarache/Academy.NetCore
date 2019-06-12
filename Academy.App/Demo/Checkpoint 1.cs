using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Academy.App.Demo
{
    public class Checkpoint_1
    {
        public void Run()
        {
            //Console.WriteLine("Enter command, e.g. 5-7-11:");
            //string[] triangles = Console.ReadLine().Split('-');

            //foreach (var triangleCommand in triangles)
            //{
            //    int.TryParse(triangleCommand, out int currentTriangleSize);
            //    for (int rowNumber = 0; rowNumber < currentTriangleSize; rowNumber++)
            //    {
            //        for (int columnNumber = 0; columnNumber <= rowNumber; columnNumber++)
            //        {
            //            Console.Write("*");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}

            //// Level 2
            //Console.WriteLine("Enter command, e.g. A5-B7-A11:");
            //string[] trianglesRedux = Console.ReadLine().Split('-');
            //foreach (var triangleCommand in trianglesRedux)
            //{
            //    //char direction = triangleCommand[0];
            //    string directionString = triangleCommand.Substring(0, 1);

            //    int.TryParse(triangleCommand, out int currentTriangleSize);
            //    for (int rowNumber = 0; rowNumber < currentTriangleSize; rowNumber++)
            //    {
            //        for (int columnNumber = 0; columnNumber <= rowNumber; columnNumber++)
            //        {
            //            Console.Write("*");
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();

            //}


            Console.WriteLine("Enter command, e.g. A5-B7-C11-D15:");

            Console.ReadLine()
                .Split('-')
                .Select(a =>
                    new Tuple<string, int>(
                        a.Substring(0, 1).ToUpper(),
                        int.TryParse(a.Substring(1), out int parsedInt) ? parsedInt : 0
                    )
                )
                .ToList()
                .ForEach(a =>
                {
                    StringBuilder sb = new StringBuilder();
                    int middle = (a.Item2 / 2);
                    switch (a.Item1)
                    {
                        case "A":
                            for (int i = 0; i < a.Item2; i++)
                            {
                                for (int j = 0; j < i; j++)
                                {
                                    sb.Append("*");
                                }
                                sb.AppendLine();
                            }
                            break;
                        case "B":
                            for (int i = a.Item2; i > 0; i--)
                            {
                                for (int j = i; j > 0; j--)
                                {
                                    sb.Append("*");
                                }
                                sb.AppendLine();
                            }
                            break;
                        case "C":
                            for (int i = 0; i <= a.Item2; i++)
                            {
                                if (i <= middle)
                                {
                                    for (int j = 0; j < i; j++)
                                    {
                                        sb.Append("*");
                                    }
                                }
                                else
                                {
                                    for (int j = a.Item2 - i + 1; j > 0; j--)
                                    {
                                        sb.Append("*");
                                    }
                                }
                                sb.AppendLine();
                            }
                            break;
                        case "D":
                            for (int i = 0; i <= a.Item2; i++)
                            {
                                if (i <= middle)
                                {
                                    sb.Append("*".PadLeft(a.Item2 - i));
                                    for (int j = 0; j < i; j++)
                                    {
                                        sb.Append("*");
                                    }
                                }
                                else
                                {
                                    sb.Append("*".PadLeft(i));
                                    for (int j = a.Item2 - i; j > 0; j--)
                                    {
                                        sb.Append("*");
                                    }
                                }
                                sb.AppendLine();
                            }
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(sb.ToString());
                });

        }
    }
}
