using Academy.ConsoleApp.Classes.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    /// <summary>
    /// Exercise that covers parts of inheritance in C#.
    /// </summary>
    public class InheritanceExercise
    {
        /// <summary>
        /// This is the entry point for the inheritance exercise.
        /// </summary>
        public void Run()
        {
            //Rectangle rectangle = new Rectangle(5.5, 9.83);
            //Console.WriteLine(rectangle.ToString());

            // Polymorphism
            List<Shape> allShapes = AskForShapes();

            PrintAllShapes(allShapes);


        }

        /// <summary>
        /// This method will print all properties in the shapes list.
        /// </summary>
        /// <param name="shapes">The list with all classes that inherites or is of type Shape.</param>
        private void PrintAllShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.HelloType());
                Console.WriteLine(shape.ToString());
                Console.WriteLine(Math.Round(shape.CalculateArea(), 2));
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method that asks for shapes to be added to an list.
        /// </summary>
        /// <returns>A list with shapes that can be triangle, rectangle and circles.</returns>
        private List<Shape> AskForShapes()
        {
            List<Shape> allShapes = new List<Shape>();
            while (true)
            {
                Console.WriteLine("Select (T)riangle, (C)ircle, (R)ectangle or (D)one.");
                char pressedKey = Console.ReadKey().KeyChar;
                switch (pressedKey.ToString().ToLower())
                {
                    case "t":
                        Triangle myTriangle = AskForTriangle();
                        allShapes.Add(myTriangle);
                        break;
                    case "r":
                        allShapes.Add(AskForRectangle());
                        break;
                    case "c":
                        allShapes.Add(AskForCircle());
                        break;
                    case "d":
                        return allShapes;
                }
            }
        }

        /// <summary>
        /// Method that creates a Circle object based on user input.
        /// </summary>
        /// <returns>A circle object.</returns>
        private Circle AskForCircle()
        {
            Console.WriteLine("Enter radius of circle:");
            string myRadiusValue = Console.ReadLine();

            // Ett exempel på hur man castar en string till en double.
            double radius;
            double.TryParse(myRadiusValue, out radius);

            Circle circle = new Circle(radius);
            return circle;
        }

        /// <summary>
        /// Method that creates a rectangle object based on user input.
        /// </summary>
        /// <returns>A rectangle object.</returns>
        private Rectangle AskForRectangle()
        {
            Console.WriteLine("Enter base of rectangle:");
            string myWidth = Console.ReadLine();
            Console.WriteLine("Enter height of rectangle:");
            string myHeight = Console.ReadLine();

            double.TryParse(myWidth, out double width);
            double.TryParse(myHeight, out double height);

            Rectangle rectangle = new Rectangle(width, height);
            return rectangle;
        }

        /// <summary>
        /// Method that creates a triangle object based on user input.
        /// </summary>
        /// <returns>A triangle object.</returns>
        private Triangle AskForTriangle()
        {
            Console.WriteLine("Enter base of triangle:");
            string myBaseLength = Console.ReadLine();
            Console.WriteLine("Enter height of triangle:");
            string myHeight = Console.ReadLine();

            bool parseBaseLengthSucceeded = double.TryParse(myBaseLength, out double baseLength);
            double.TryParse(myHeight, out double height);

            Triangle triangle = new Triangle(baseLength, height);

            return triangle;
        }
    }
}
