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
        public readonly IHomeKikanSystem homeKikanSystem;

        public HomeController(ICommonKikanSystem _context, IHomeKikanSystem _homeKikanSystem)
        {
            this.context = _context;
            this.homeKikanSystem = _homeKikanSystem;
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
                var resultCheck = new FunctionValidationToken(this.context);
                bool tokenValidationResult = await resultCheck.ValidationTokenEmployeer(Carshier);

                if (tokenValidationResult == true) 
                {
                    // Concat string
                    string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventInitialization);
                    var cookies = Request.Cookies["LoginTDTImportKikanSystem"].ToString();
                    // Innit Number Data 
                    var dataInitia = new InitializationDataHome()
                    {
                        Token = cookies,
                        EventCode = eventCode
                    };
                    // Conver Object to Json
                    string jsonConver = CommonConverJsonToObject<InitializationDataHome>.CoverObjectToJson(dataInitia);
                    var result = await this.homeKikanSystem.Initialization(jsonConver);
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

        /// <summary>
        /// ImportBooks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ImportBooks()
        {
            return View();
        }
    }
}
