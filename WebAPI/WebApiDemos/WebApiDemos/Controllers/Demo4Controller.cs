using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemos.Models;

namespace WebApiDemos.Controllers
{
    [Route("demo4")]
    public class Demo4Controller : Controller
    {
        [HttpPost("addmeeting")]
        public IActionResult AddMeeting(Meeting meeting)
        {
            if (meeting.Name != null || meeting.Name.Length == 0)
            {
                return BadRequest("Namn är obligatoriskt.");
            }

            if (meeting.Place != null || meeting.Place.Length == 0)
            {
                return BadRequest("Plats är obligatoriskt.");
            }

            return Ok("Mötet skapades.");
        }

        [HttpPost("AddMeetingWithAttribute")]
        public IActionResult AddMeetingWithAttribute(Meeting meeting)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder errorText = new StringBuilder();
                foreach (var error in ModelState)
                {
                    if (ModelState[error.Key].ValidationState != ModelValidationState.Valid)
                    {
                        errorText.AppendLine($"{error.Key} - {ModelState[error.Key].Errors[0].ErrorMessage}");
                    }
                }
                return BadRequest(errorText.ToString());

                //return BadRequest(ModelState);
            }
            return Ok("Mötet skapades.");
        }
    }
}
