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
            Planet planet = Planet.ParsePlanet(formContent);
            return Ok($"Ny planet {planet.Name} skapad med storleken {planet.Size}.");
        }

        [Route("SearchPlanet")]
        public IActionResult SearchPlanet()
        {
            string formData = Request.QueryString.ToString();
            Planet planet = Planet.ParsePlanet(formData);

            return Ok($"Söker i databasen efter planeter med namn {planet.Name} och storlek {planet.Size}");
        }

    }
}
