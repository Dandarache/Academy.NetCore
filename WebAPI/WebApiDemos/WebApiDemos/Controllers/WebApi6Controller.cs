using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemos.Models;

namespace WebApiDemos.Controllers
{
    [Route("webapi6")]
    public class WebApi6Controller : Controller
    {
        [HttpPost("AddDocument")]
        public IActionResult AddDocument(Document document)
        {
            return Ok(document);
        }

    }
}
