using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVC01.Models;
using MVC01.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC01.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;

        /// <summary>
        /// Dependency injection kommer att ge oss en instans av ProductRepository,
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        //private IHostingEnvironment _env;
        //public ProductController(IHostingEnvironment hostingEnvironment)
        //{
        //    _env = hostingEnvironment;
        //    _productRepository = new ProductRepository(_env);
        //}

        //public ProductController()
        //{
        //    _productRepository = new ProductRepository();
        //}

        #region Dummy methods

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
            return View("~/Views/Dummy/Dan.cshtml", model);
            //return View("Danne", model);

        }

        #endregion

        public IActionResult GetProduct(int id)
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

            return View("GetProduct", viewModel);
        }

        [HttpGet] // Är default för alla ActionResult-metoder.
        public IActionResult Index()
        {
            //var productRepository = new ProductRepository();
            //var model = _productRepository.GetAll();

            var viewModel = new ProductViewModel
            {
                Products = _productRepository.GetAll()
            };

            return View(viewModel);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product currentProduct)
        {
            _productRepository.Add(currentProduct);

            //return View("ProductAdded");
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(int id)
        {
            var product = _productRepository.GetById(id);

            var viewModel = new ProductViewModel
            {
                CurrentProduct = product,
            };

            return View("UpdateProduct", viewModel);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product currentProduct)
        {
            _productRepository.Update(currentProduct);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            _productRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
