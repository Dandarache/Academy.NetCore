using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApiDemos.Models;

namespace WebApiDemos.Controllers
{
    [Route("webapi1")]
    public class WebApi1Controller : Controller
    {
        [Route("AddPlanet")]
        public IActionResult AddPlanet()
        {
            string formContent = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                formContent = reader.ReadToEndAsync().Result;
            }

            // Du behöver göra "Planet"-klassen och metoden "ParsePlanet"
            Planet planet = ParsePlanet(formContent);
            return Ok($"Ny planet {planet.Name} skapad med storleken {planet.Size}.");
        }

        private Planet ParsePlanet(string formContent)
        {
            Regex regex1 = new Regex("(&|^)Name=([^&$]*)");
            var planetName = regex1.Match(formContent).Groups[2].Value;

            Regex regex2 = new Regex("(&|^)Size=([^&$]*)");
            var planetSizeString = regex2.Match(formContent).Groups[2].Value;
            int.TryParse(planetSizeString, out int planetSize);

            return new Planet
            {
                Name = planetName,
                Size = planetSize
            };
        }
    }
}
