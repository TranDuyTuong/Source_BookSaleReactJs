using Microsoft.AspNetCore.Mvc;

namespace TXTKikanSystem.Controllers
{
    public class SignInController : Controller
    {
        /// <summary>
        /// Login KikanSystem
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password) {
            return new JsonResult(0);
        }

    }
}
