using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemos.Controllers
{
    /// <summary>
    /// Route attributet gör att denna route läggs till bland tillgängliga router i projektet.
    /// Det innebär att när en förfrågan mot /demo1 kommer till servern så kommer den att mappas mot denna kontroller.
    /// </summary>
    [Route("demo1")]
    public class Demo1Controller : Controller
    {
        /// <summary>
        /// HttpGet attributet är default och behöver egentligen inte skrivas in i koden.
        /// I detta exempel har den lagts till för att mappa det metodnamn så står mellan parenteserna mot den actionmetod som inkommiy via routen.
        /// </summary>
        /// <param name="painter"></param>
        /// <param name="paintedDate"></param>
        /// <returns></returns>
        [HttpGet("GetPainting1")]
        public IActionResult GetPainting1(string painter, DateTime paintedDate)
        {
            return Ok($"Hello Painting: {painter}");
        }

        /// <summary>
        /// HttpGet attributet är default och behöver egentligen inte skrivas in i koden.
        /// I detta exempel har den lagts till för att mappa det metodnamn så står mellan parenteserna mot den actionmetod som inkommiy via routen.
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetPainting2")]
        public IActionResult GetPainting2(RequestData request)
        {
            return Ok($"Hello Painting (2): {request.Painter}");
        }



    }

    public class RequestData
    {
        public string Painter { get; set; }
        public DateTime PaintedDate { get; set; }
    }

}