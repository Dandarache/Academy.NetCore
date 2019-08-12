using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemos.Controllers
{
    [Route("webapi3")]
    public class WebApi3Controller : Controller
    {

        [HttpGet("Breakfast")]
        public IActionResult Breakfast(string food)
        {
            if (string.IsNullOrWhiteSpace(food))
                return Ok("Skriv in din frukostmat");

            food = food.Trim();

            if (food.ToLower() == "mango")
                return Ok("Mango är gott!");

            return Ok(CapitalizeFirstLetter(food) + " är äckligt!");
        }


        [HttpGet("Square")]
        public IActionResult Square(int number)
        {
            int numberedSquared = number * number;
            string message = $"{number} * {number} = {numberedSquared}";
            return Ok(message);
        }

        [HttpGet("Range")]
        public IActionResult Range(int from, int to)
        {
            var numbers = new List<int>();

            for (int i = from; i <= to; i++)
            {
                numbers.Add(i);
            }

            string numbersAsString = string.Join(",", numbers);

            return Ok(numbersAsString);
        }

        [HttpGet("RangeLinq")]
        public IActionResult Range_Linq(int from, int to)
        {
            return Ok(string.Join(",", Enumerable.Range(from, to - from + 1)));
        }

        [HttpGet("SetBackground")]
        public IActionResult SetBackground(string color)
        {
            string html = $"<body style='background-color:{color}'></body>";
            return Content(html, "text/html");
        }

        private string CapitalizeFirstLetter(string word)
        {
            return word[0].ToString().ToUpper() + word.Substring(1).ToLower();
        }
    }
}
