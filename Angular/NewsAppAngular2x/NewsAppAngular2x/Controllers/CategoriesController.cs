using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NewsAppAngular2x.Models;

namespace NewsAppAngular2x.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var all = _categoryRepository.GetAll().OrderBy(x=>x.Name);
            return Ok(all);
        }

    }
}
