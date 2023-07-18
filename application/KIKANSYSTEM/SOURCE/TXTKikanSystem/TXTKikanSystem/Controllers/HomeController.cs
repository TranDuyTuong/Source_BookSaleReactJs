using CommonApi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;
using TXTKikanSystem.FunctionLocation;
using TXTKikanSystem.Models;

namespace TXTKikanSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommonKikanSystem context;

        public HomeController(ICommonKikanSystem _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// Home Page Index 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(string Carshier)
        {
            // Check input data
            if(Carshier == null)
            {
                return RedirectToAction("Login", "SignIn");
            }
            else
            {
                // Check token result
                var resultCheck = new FunctionValidationToken();
                bool tokenValidationResult = await resultCheck.ValidationTokenEmployeer(Carshier);

                if (tokenValidationResult == true) 
                {
                    // Reditrectoaction Home Page
                    return View();
                }
                else
                {
                    // Reditrectoaction Login Page
                    return RedirectToAction("Login", "SignIn");
                }
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
