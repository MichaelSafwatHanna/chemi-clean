using ChemiClean.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChemiClean.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(ProductsRepository.GetInstance().GetAll());
        }

        [HttpGet]
        [Route("home/{name}")]
        public ActionResult ProductByName(string name)
        {
            return View(ProductsRepository.GetInstance().Get(name));
        }
    }
}
