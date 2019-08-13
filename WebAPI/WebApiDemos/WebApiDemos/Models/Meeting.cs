using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemos.Models
{
    public class Meeting
    {
        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Plats är obligatoriskt.")]
        public string Place { get; set; }

        public string Agenda { get; set; }
    }
}
