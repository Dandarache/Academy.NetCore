using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApiDemos.Controllers
{
    [Route("demo2")]
    public class Demo2Controller : Controller
    {
        [Route("CheckFileFormat")]
        public IActionResult CheckFileFormat()
        {
            string fileFormatData = Request.QueryString.Value;

            //string fileFormat = new Regex(@"(&|^|\?)fileformat=([^&$]*)").Match(fileFormatData).Groups[2].Value;
            string fileFormat = Request.Query["fileformat"];

            if (fileFormat.Length != 3)
            {
                return BadRequest($"Invalid file format.");
            }

            switch (fileFormat.ToUpper())
            {
                case "SEC":
                    return Unauthorized();
                case "FOO":
                    return NotFound($"Current file format '{fileFormat}' is not supported.");
                case "GIF":
                    return Content(
                        $"<img src='https://media1.giphy.com/media/SC0VDXns3gvS0/giphy.gif' />", 
                        "text/html");
                case "JPG":
                    return Content(
                        $"<img src='https://royvanrijn.com/images/oh-no-the-robots.jpg' />", 
                        "text/html");
                default:
                    return BadRequest($"Invalid file format.");
            }

        }
    }
}
