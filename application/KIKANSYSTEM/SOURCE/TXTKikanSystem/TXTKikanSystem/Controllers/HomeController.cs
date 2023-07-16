using Microsoft.AspNetCore.Mvc;

namespace TXTKikanSystem.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home Page Index 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
