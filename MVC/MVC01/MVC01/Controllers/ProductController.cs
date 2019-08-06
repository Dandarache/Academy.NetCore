using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC01.Models;
using MVC01.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC01.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
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
            //return View();
            return View("~/Views/Product/Dan.cshtml", model);
            //return View("Danne", model);

        }

        public IActionResult Get(int id)
        {
            //var productRepository = new ProductRepository();

            //var product = _productRepository.GetAll().FirstOrDefault(prod => prod.Id.Equals(id));
            var product = _productRepository.GetById(id);
            var allProducts = _productRepository.GetAll();

            var viewModel = new ProductViewModel
            {
                CurrentProduct = product,
                Products = allProducts
            };

            return View("DisplayProduct", viewModel);
        }

        public IActionResult Index()
        {
            //var productRepository = new ProductRepository();

            var model = _productRepository.GetAll();
            return View(model);
        }

    }
}
