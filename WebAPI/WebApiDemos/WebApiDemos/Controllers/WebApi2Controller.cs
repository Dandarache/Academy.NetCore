using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemos.Controllers
{
    [Route("webapi2")]
    public class WebApi2Controller : Controller
    {
        [HttpGet("HelloWorld")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello world");
        }

        [HttpGet("Number")]
        public int Number()
        {
            return 42;
        }

        [HttpGet("HelloWorld2")]
        public IActionResult HelloWorld2()
        {
            return Ok("Hello world - with IActionResult");
        }

        [HttpGet("Weekday")]
        public IActionResult Weekday()
        {
            return Ok($"Today it is {DateTime.Now.DayOfWeek}");
            //return Ok($"Idag är det {DateTime.Now.ToString("dddd", new CultureInfo("sv"))}");
        }

        [HttpGet("ClicheOfTheDay")]
        public IActionResult ClicheOfTheDay()
        {
            string message = "";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday: message = "Uh-oh. Sounds like somebody's got a case of the mondays."; break;
                case DayOfWeek.Tuesday: message = "Tuesday text"; break;
                case DayOfWeek.Wednesday: message = "Wednesday text"; break;
                case DayOfWeek.Thursday: message = "Thursday text"; break;
                case DayOfWeek.Friday: message = "Friday text"; break;
                case DayOfWeek.Saturday: message = "Saturday text"; break;
                case DayOfWeek.Sunday: message = "Sunday text"; break;
                default: throw new Exception($"Don't recognize weekday {DateTime.Now.DayOfWeek}");
            }

            return Ok(message);
        }

    }
}
