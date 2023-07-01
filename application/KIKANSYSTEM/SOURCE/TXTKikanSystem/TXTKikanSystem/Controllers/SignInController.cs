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

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string email, string password) {
            return new JsonResult(0);
        }

    }
}
