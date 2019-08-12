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
            return Ok();
        }

    }
}
