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
            if (Carshier == null)
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
                        EventCode = eventCode,
                        Company = CommonEventCode.CompanyCode,
                        AreaCode = CommonEventCode.AreaCode,
                        StoreCode = CommonEventCode.StoreCode
                    };
                    // Conver Object to Json
                    string jsonConver = CommonConverJsonToObject<InitializationDataHome>.CoverObjectToJson(dataInitia);
                    var result = await this.homeKikanSystem.Initialization(jsonConver);
                    // Conver Json to Object
                    var InitData = CommonConverJsonToObject<InitializationDataHome>.ConverJsonToObject(result);

                    if (InitData.Status == true)
                    {
                        // If success
                        foreach (var item in InitData.ListDataInitia)
                        {
                            string[] slipItem = item.ToString().Split('_');
                            switch (slipItem[0])
                            {
                                case "Books":
                                    ViewBag.books = slipItem[1].ToString();
                                    break;
                                case "Category":
                                    ViewBag.category = slipItem[1].ToString();
                                    break;
                                case "City":
                                    ViewBag.citys = slipItem[1].ToString();
                                    break;
                                case "District":
                                    ViewBag.district = slipItem[1].ToString();
                                    break;
                                case "Authors":
                                    ViewBag.author = slipItem[1].ToString();
                                    break;
                                case "PublishingCompany":
                                    ViewBag.publishingCompany = slipItem[1].ToString();
                                    break;
                                case "Publisher":
                                    ViewBag.publisher = slipItem[1].ToString();
                                    break;
                                case "BankSuport":
                                    ViewBag.bankSuport = slipItem[1].ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        // If Fail
                        ViewBag.books = "Error: Not Find Number Book, Please Contact Manager!";
                        ViewBag.category = "Error: Not Find Number Category, Please Contact Manager!";
                        ViewBag.citys = "Error: Not Find Number Citys, Please Contact Manager!";
                        ViewBag.district = "Error: Not Find Number District, Please Contact Manager!";
                        ViewBag.author = "Error: Not Find Number Author, Please Contact Manager!";
                        ViewBag.publishingCompany = "Error: Not Find Number PublishingCompany, Please Contact Manager!";
                        ViewBag.publisher = "Error: Not Find Number Publisher, Please Contact Manager!";
                        ViewBag.bankSuport = "Error: Not Find Number BankSuport, Please Contact Manager!";

                    }

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
