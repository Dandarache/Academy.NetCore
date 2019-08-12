using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiDemos.Controllers
{
    [Route("webapi4")]
    public class WebApi4Controller : Controller
    {
        [HttpGet("LightBulb")]
        public IActionResult LightBulb(bool light)
        {
            string backgroundColor = light ? "yellow" : "#ddd";

            string html = $"<body style='background-color:{backgroundColor}'></body>";
            return Content(html, "text/html");
        }

        [HttpGet("ChocolatePieces")]
        public IActionResult ChocolatePieces(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                return BadRequest($"För få personer: {numberOfPeople}");
            }

            double result = 25.0 / numberOfPeople;

            return Ok($"Varje person får {result:.##} bitar");

        }

        [HttpGet("LookupOrder")]
        public IActionResult LookupOrder(string orderId)
        {
            Match match = Regex.Match(
                orderId,
                @"^([a-zA-Z]{2})-([012]?\d{3})$", 
                RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                return BadRequest("Fel format på orderId");
            }

            string alphaPart = match.Groups[1].Value;
            int numberPart = int.Parse(match.Groups[2].Value);

            if (numberPart > 2999)
            {
                return NotFound($"Order {orderId} hittades ej");
            }

            return Ok($"Order {orderId} hittades i databasen");

        }

        [HttpGet("CheckUser")]
        public IActionResult CheckUser(string userName)
        {
            if (userName == "Stewie")
            {
                throw new Exception("DATA ERROR!");
            }

            if (userName == "Peter")
            {
                return Content("<img src='/images/explosion.jpg' />", "text/html");
            }

            string[] allowedUserNames = { "Lois", "Meg", "Chris", "Brian" };

            if (allowedUserNames.Contains(userName))
            {
                return Content("<img src='/images/thumbs-up.jpg' />", "text/html");
            }
            else
            {
                return Content("<img src='/images/thumbs-down.svg' />", "text/html");
            }
        }

    }
}
