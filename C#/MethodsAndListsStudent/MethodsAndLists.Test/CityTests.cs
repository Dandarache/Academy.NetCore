using MethodsAndLists.Core.Enums;
using MethodsAndLists.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class CityTests
    {
        [TestMethod]
        [DataRow("Stockholm, 2000000", "Stockholm", 2000000)]
        [DataRow("Västerås, 140000", "Västerås", 140000)]
        [DataRow("Borlänge, 50000", "Borlänge", 50000)]
        public void city_tostring_should_return_city_and_population(string expected, string cityName, int poulation)
        {
            City myCity = new City
            {
                Name = cityName,
                Population = poulation
            };

            Assert.AreEqual(expected, myCity.ToString());
        }

        [TestMethod]
        [DataRow(CityType.Large, "Stockholm", 2000000)]
        [DataRow(CityType.Normal, "Västerås", 140000)]
        [DataRow(CityType.Small, "Sälen", 6000)]
        public void city_citysize_should_return_valid_citysize(CityType expected, string cityName, int poulation)
        {
            City myCity = new City
            {
                Name = cityName,
                Population = poulation
            };

            Assert.AreEqual(expected, myCity.CitySize);
        }
    }
}
