using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class SquareRootExtraController : Controller
    {
        [HttpGet]
        [Route("api/squarerootextra")]
        public IActionResult SquareRoot(int? number, int? nrOfDigits)
        {
            List<string> errorMessages = new List<string>();

            if (number == null)
                errorMessages.Add("Enter a number");
            else if (number < 0)
                errorMessages.Add("Can't square root negative numbers");

            if (nrOfDigits == null)
                errorMessages.Add("Enter number of digits");

            else if (nrOfDigits < 0)
                errorMessages.Add("Number of digits must be greater than 0");

            if (errorMessages.Any())
                return BadRequest(errorMessages);

            double result = Math.Sqrt((int) number);
            result = Math.Round(result, (int)nrOfDigits);
            return Ok(result);
        }
    }
}
