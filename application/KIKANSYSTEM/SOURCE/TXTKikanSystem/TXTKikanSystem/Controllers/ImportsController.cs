using CommonApi;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;
using TXTKikanSystem.FunctionLocation;
using TXTKikanSystem.Models;

namespace TXTKikanSystem.Controllers
{
    public class ImportsController : Controller
    {
        private readonly ICommonKikanSystem context;
        public readonly IHomeKikanSystem homeKikanSystem;
        public readonly IimportDataKikaSystem importData;

        public ImportsController(ICommonKikanSystem _context, IHomeKikanSystem _homeKikanSystem, IimportDataKikaSystem _importData)
        {
            this.context = _context;
            this.homeKikanSystem = _homeKikanSystem;
            this.importData = _importData;
        }

        /// <summary>
        /// Books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Books(string Carshier)
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
                    string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventImportBooks);
                    var cookies = Request.Cookies["LoginTDTImportKikanSystem"].ToString();
                    // Get User And Role Request
                    string[] inputData = Carshier.Split("*");
                    // Innit Number Data 
                    var dataInitia = new TemplateImportKikanSystem()
                    {
                        Token = cookies,
                        EventCode = eventCode,
                        Company = CommonEventCode.CompanyCode,
                        AreaCode = CommonEventCode.AreaCode,
                        StoreCode = CommonEventCode.StoreCode,
                        TypeImport = EnumImportData.Excelimport_Books,
                        UserID = inputData[0],
                        Role = inputData[1]
                        
                    };
                    // Conver Object to Json
                    string jsonConver = CommonConverJsonToObject<TemplateImportKikanSystem>.CoverObjectToJson(dataInitia);
                    var result = await this.importData.ImportDataByKikaSystem(jsonConver);
                    // Conver Json to Object
                    var InitData = CommonConverJsonToObject<TemplateImportKikanSystem>.ConverJsonToObject(result);

                    if(InitData == null)
                    {
                        ViewBag.InitDataNull = MessageNotification.CommonMesage.Message.MessageErrorCallAPIfali;
                    }
                    else
                    {
                        // Check result
                        if (InitData.Status == false)
                        {
                            ViewBag.InitDataNull = MessageNotification.CommonMesage.Message.MessageInitializationDataFail;
                        }
                        else
                        {
                            // Get Content Template
                            List<string> l_TitleTemplate = new List<string>();
                            string[] templateContent = InitData.ContentTemplate.Split(",");

                            for (int i = 0; i < templateContent.Length; i++)
                            {
                                l_TitleTemplate.Add(templateContent[i]);
                            }

                            // Save List Template into ViewBag
                            ViewBag.listTemplate = l_TitleTemplate;
                            // Get File Name Request
                            ViewBag.fileName = InitData.NameFile;
                            // Suport Create File Import By Template
                            ViewBag.instruct = MessageNotification.CommonMesage.Message.MessageSuportCreateByTemplate;
                            // Notification Get 1000 Recol
                            ViewBag.getRecol = MessageNotification.CommonMesage.Message.MessageSystemGet1000Recol;
                        }

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


    }
}
