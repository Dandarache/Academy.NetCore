using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiDemos.Models
{
    public class Planet
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public static Planet ParsePlanet(string planetData)
        {
            Regex regex1 = new Regex("(&|^|\\?)Name=([^&$]*)");
            var planetName = regex1.Match(planetData).Groups[2].Value;

            Regex regex2 = new Regex(@"(&|^|\?)Size=([^&$]*)");
            var planetSizeString = regex2.Match(planetData).Groups[2].Value;
            int.TryParse(planetSizeString, out int planetSize);

            return new Planet
            {
                Name = planetName,
                Size = planetSize
            };
        }
    }
}
