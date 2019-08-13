using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    public class SquareRootController : Controller
    {
        [HttpGet("api/squareroot")]
        public IActionResult SquareRoot(int? number)
        {
            if (number == null)
            {
                return BadRequest("Enter a number");
            }

            if (number < 0)
            {
                return BadRequest("Can't square root negative numbers");
            }
            return Ok(Math.Sqrt((int)number));
        }

        // Alternativ för att det ska bli mer konsekvent och slippa använda "response.text" i javascript.
        [HttpGet("api/squareroot-alternative")]
        public IActionResult SquareRoot_Alternative(int? number)
        {
            if (number == null)
            {
                return BadRequest(new { ErrorMessage = "Enter a number", SomethingMore = 15 });
            }

            if (number < 0)
            {
                return BadRequest(new { ErrorMessage = "Can't square root negative numbers", SomethingMore = 25 });
            }

            return Ok(Math.Sqrt((int)number));
        }
    }
}
