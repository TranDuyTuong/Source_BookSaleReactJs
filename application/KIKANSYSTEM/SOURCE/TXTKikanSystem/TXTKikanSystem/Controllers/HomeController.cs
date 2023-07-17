using Microsoft.AspNetCore.Mvc;

namespace TXTKikanSystem.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home Page Index 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string Carshier)
        {
            // Check input data
            if(Carshier == null)
            {
                return RedirectToAction("Login", "SignIn");
            }
            else
            {
                // Check Carshier data
                string[] inputData = Carshier.Split("+");
                return View();
            }
        }

        /// <summary>
        /// HeaderMenu
        /// </summary>
        /// <returns></returns>
        public IActionResult HeaderMenu()
        {
            return PartialView();
        }
    }
}
