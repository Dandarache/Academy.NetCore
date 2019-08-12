using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemos.Controllers
{
    [Route("demo3")]
    public class Demo3Controller : Controller
    {
        [HttpGet("CheckMemberGet")]
        //[Route("CheckMemberGet")]
        public IActionResult CheckMemberGet(
            string username, 
            bool isMember, 
            string firstName, 
            string lastName)
        {
            return Ok("Det gick bra!");
        }

        [HttpPost("CheckMemberPost")]
        public IActionResult CheckMemberPost(
            string username,
            bool isMember,
            string firstName,
            string lastName)
        {
            return Ok("Det gick bra!");
        }

    }
}
