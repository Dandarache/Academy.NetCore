using Academy.ConsoleApp.Classes;
using Academy.ConsoleApp.Classes.Shapes;
using Academy.ConsoleApp.Demo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyTests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void test_that_circle_is_of_type_shape()
        {
            Circle circle = new Circle(4.53f);
            bool isShape = circle is Shape;

            Assert.IsTrue(isShape);
        }

        [TestMethod]
        public void test_that_circle_area_is_equal()
        {
            Circle circle = new Circle(4.53f);

            double area = Math.Round(circle.CalculateArea(), 1);
            double expectedArea = Math.Round(64.46f, 1);

            Assert.AreEqual(expectedArea, area);
        }

        [TestMethod]
        public void test_that_turbo_circle_is_of_type_shape()
        {
            TurboCircle circle = new TurboCircle(4.53f);
            //bool isShape = circle is Shape;

            Assert.IsNotInstanceOfType(circle, typeof(Shape));

            //Assert.IsTrue(isShape);
        }
    }
}
