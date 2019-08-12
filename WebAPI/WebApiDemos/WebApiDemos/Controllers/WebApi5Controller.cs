using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemos.Models;

namespace WebApiDemos.Controllers
{
    [Route("webapi5")]
    public class WebApi5Controller : Controller
    {
        [HttpPost("AddPerson")]
        public IActionResult AddPerson(SimplePerson person)
        {
            string message = $"Du har angett {person.FirstName} som är {person.Age} år";
            return Ok(message);
        }

        [HttpPost("AddPersonValidate")]
        public IActionResult AddPersonValidate(SimplePerson person)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(person.FirstName))
            {
                errors.Add("Förnamnet får inte vara tomt");
            }

            if (person.FirstName?.Length > 20)
            {
                errors.Add("Förnamnet får inte innehålla fler än 20 tecken");
            }

            if (person.Age == null)
            {
                errors.Add("Ålder måste anges");
            }

            if (person.Age < 0 || person.Age > 120)
            {
                errors.Add("Ålder måste vara mellan 0 och 120");
            }

            if (errors.Count > 0)
            {
                return BadRequest(string.Join(". ", errors));
            }
            else
            {
                return Ok($"Du har angett {person.FirstName} som är {person.Age} år");
            }

        }

        [HttpPost("AddPersonValidateAttribute")]
        public IActionResult AddPersonValidateAttribute(SimplePersonWithAttributes person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok($"Du har angett {person.FirstName} som är {person.Age} år");
        }
    }
}
