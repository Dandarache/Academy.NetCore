using Academy.ConsoleApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class ClassesDemo0
    {
        public void Run()
        {
            // Cars
            //  Color
            //  Weight
            //  Brand

            //////////////////////////////////
            // DEMO 1
            //////////////////////////////////

            //string brand1 = "Volvo";
            //string color1 = "Red";
            //int weight1 = 1300;

            //string brand2 = "Mercedes";
            //string color2 = "Green";
            //int weight2 = 1700;

            //Console.WriteLine($"First car: {brand1}, Color: {color1}, Weight: {weight1}");
            //Console.WriteLine($"Second car: {brand2}, Color: {color2}, Weight: {weight2}");

            //////////////////////////////////
            // DEMO 2
            //////////////////////////////////

            Car car1 = new Car();
            car1.Brand = "Volvo";
            car1.SetColor("Red");
            car1.SetWeight(1300);

            Car car2 = new Car();
            car2.Brand = "Mercedes";
            car2.SetColor("Green");
            car2.SetWeight(1700);

            //////////////////////////////////
            // DEMO 3
            //////////////////////////////////
            car1.StartEngine();

            Console.WriteLine($"First car: {car1.BrandUppercase}, Color: {car1.GetColor()}, Weight: {car1.GetWeight()}, Is engine running: {car1.GetEngineRunning()}");
            Console.WriteLine($"Second car: {car2.Brand}, Color: {car2.GetColor()}, Weight: {car2.GetWeight()}, Is engine running: {car2.GetEngineRunning()}");

        }
    }
}
