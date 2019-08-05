﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC01.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> Products {
            get {
                return new List<Product> {
                    new Product {
                        Id = 123,
                        Name = "Strumpor",
                        Description = "Super socks for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "ABC9897"
                    },
                    new Product {
                        Id = 456,
                        Name = "Skjorta",
                        Description = "Super shirt for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "CDE7481"
                    },
                    new Product {
                        Id = 458,
                        Name = "Byxor",
                        Description = "Super pants for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "CDE9781"
                    },
                    new Product {
                        Id = 897,
                        Name = "Mössa",
                        Description = "Super cap for super men and women. Yay, hooray, fantastic today!",
                        ProductNumber = "QWE6767"
                    },
                };
            }
        }

        [Route("testy")]
        public IActionResult Testy()
        {
            return Ok("Testy funkar!");
            //return NotFound("Testy funkar!");
            //return View();
        }

        //[Route("dan")]
        public IActionResult Dan()
        {
            var model = "Dan Jansson is best!";
            return View("Dan", model);
        }

        public IActionResult Get(int id)
        {
            var model = Products.FirstOrDefault(prod => prod.Id.Equals(id));
            return View("DisplayProduct", model);
        }

        public IActionResult Index()
        {
            var model = Products;
            return View(model);
        }

    }
}