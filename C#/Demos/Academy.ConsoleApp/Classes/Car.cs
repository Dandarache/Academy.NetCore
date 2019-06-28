using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes
{
    // Detta är en kommentar...
    public class Car
    {

        // Field Variables should never be public!
        //public string Color;
        //public int Weight;
        //public string Brand;

        // Field variables for the class.
        // Default accessor for field variables is private.
        string _color;
        int _weight;
        int _maximumLoad;
        private bool engineRunning = false;

        // Instance methods that sets or gets the color of the car.
        public void SetColor(string color)
        {
            _color = color;
        }
        public string GetColor()
        {
            return _color;
        }

        // Instance methods that sets or gets the weight of the car.
        // The setter also calculates the maximum load for the car.
        public void SetWeight(int weight)
        {
            _weight = weight;
            _maximumLoad = weight - 200;

        }
        public int GetWeight()
        {
            return _weight;
        }

        // Instance method that returns the maximum load for this car.
        public int GetMaximumLoad()
        {
            return _maximumLoad;
        }

        // Auto implemented properties
        //public string Brand { get; set; }

        // Explicitly implemented properties
        private string _brand;
        public string Brand
        {
            get
            {
                return _brand;
            }
            set
            {
                _brand = value;
                BrandUppercase = value.ToUpper();
            }
        }

        // Property with private setter.
        public string BrandUppercase { get; private set; }

        // Instance method that changes state of car engine to started.
        public void StartEngine()
        {
            engineRunning = true;
        }

        // Instance method that changes state of car engine to stopped.
        public void StopEngine()
        {
            engineRunning = false;
        }

        // Instance method that returns status wheter the engine is running or not.
        public bool GetEngineRunning()
        {
            return engineRunning;
        }
    }
}
