using ClosedXML.Excel;
using CommonApi;
using MessageNotification.CommonMesage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;
using TXTKikanSystem.FunctionLocation;
using TXTKikanSystem.Models;
using TXTKikanSystem.Models.Imports;

namespace TXTKikanSystem.Controllers
{
    public class ImportsController : Controller
    {
        private readonly ICommonKikanSystem context;
        public readonly IHomeKikanSystem homeKikanSystem;
        public readonly IimportDataKikaSystem importData;

        /// <summary>
        /// List Template Excel
        /// </summary>
        private static List<string> _templateExcel = new List<string>();

        /// <summary>
        /// File Name Template Excel
        /// </summary>
        private static string _fileName = string.Empty;

        /// <summary>
        /// Message Error When Dowload Fail
        /// </summary>
        private static string _messageErrorDowload = string.Empty;

        /// <summary>
        /// Curent Page
        /// </summary>
        private static string _cutentPage = string.Empty;

        /// <summary>
        /// Save Memory Stream
        /// </summary>
        private static byte[] _saveContentMemoryStream;

        /// <summary>
        /// Save Sheet Name
        /// </summary>
        private static string _sheetName = string.Empty;

        /// <summary>
        /// Save Type Import
        /// </summary>
        private static string _typeImport = string.Empty;

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
            // Reset List Template Excel local And File Name And MessageError And curentPage And byte memory And Sheet name And Type Import
            _templateExcel = new List<string>();
            _fileName = string.Empty;
            _messageErrorDowload = string.Empty;
            _cutentPage = string.Empty;
            _saveContentMemoryStream = new byte[0];
            _sheetName = string.Empty;
            _typeImport = string.Empty;

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

                            // Save List Template in local And File Name
                            _templateExcel = l_TitleTemplate;
                            _fileName = InitData.NameFile;

                            // Save Curent Page
                            _cutentPage = "Books";

                            // Save Sheet Name
                            _sheetName = "Books";

                            // Save Type Import
                            _typeImport = EnumImportData.Excelimport_Books;
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

        /// <summary>
        /// Dowload Template
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns>File Template</returns>
        [HttpGet]
        public async Task<IActionResult> DowloadTemplate(string Carshier)
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
                    // Check List Template Local Have Data And File Name
                    if(_templateExcel.Any() == false || _fileName == string.Empty)
                    {
                        _messageErrorDowload = Message.MessageTemplateOrFileNameNull;
                        // Reditrectoaction Page Notication Template and File Name Null
                        return RedirectToAction("ErrorMessagePage", "Imports");
                    }
                    else
                    {
                        // Get type of file dowload
                        string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        string fileName = _fileName;

                        try
                        {
                            // Create Workbook
                            using(var workbook = new XLWorkbook())
                            {
                                // Create WorkSheet Name
                                IXLWorksheet worksheet = workbook.Worksheets.Add(_sheetName);

                                worksheet.ColumnWidth = 27;
                                worksheet.RowHeight = 30;

                                // Create cell in file
                                for(int i = 1; i < _templateExcel.Count; i++) 
                                {
                                    worksheet.Cell(1, i).Value = _templateExcel[i];
                                    worksheet.Cell(1, i).Style.Fill.BackgroundColor = XLColor.Yellow;
                                    worksheet.Cell(1, i).Style.Border.BottomBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, i).Style.Border.TopBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, i).Style.Border.LeftBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, i).Style.Border.RightBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, i).Style.Font.Bold = true;
                                }

                                // Save into Memory
                                using(var stream = new MemoryStream())
                                {
                                    workbook.SaveAs(stream);
                                    _saveContentMemoryStream = stream.ToArray();
                                    stream.SetLength(0);
                                    return File(_saveContentMemoryStream, contentType, fileName);
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            // Save Message Error
                            _messageErrorDowload = ex.Message;
                            // Reditrectoaction Page Notication Dowload Error
                            return RedirectToAction("ErrorMessagePage", "Imports");
                        }
                    }
                }
                else
                {
                    // Reditrectoaction Login Page
                    return RedirectToAction("Login", "SignIn");
                }
            }
        }

        /// <summary>
        /// ReadContentFileImport
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ReadContentFileImport(ImportExcelFile request)
        {
            // Check input data
            if (request.Carshier == null)
            {
                return RedirectToAction("Login", "SignIn");
            }
            else
            {
                // Check token result
                var resultCheck = new FunctionValidationToken(this.context);
                bool tokenValidationResult = await resultCheck.ValidationTokenEmployeer(request.Carshier);

                if (tokenValidationResult == true)
                {
                    try
                    {
                        // Check file Name
                        var fileName = request.ImportExcelBook.FileName;

                        if(fileName != _fileName)
                        {
                            // Save Message Error
                            _messageErrorDowload = Message.MessageFileNameIncorrect;
                            // Reditrectoaction Page Notication Dowload Error
                            return RedirectToAction("ErrorMessagePage", "Imports");
                        }
                        else
                        {                      
                            bool isReadSuccess = false;

                            // Read Content file excel
                            using(var stream = new MemoryStream())
                            {
                                await request.ImportExcelBook.CopyToAsync(stream);
                                using(var xbook = new XLWorkbook(stream))
                                {
                                    var sheetName = xbook.Worksheet(_sheetName);
                                    var rowCount = sheetName.RowCount();

                                    // Get header Template data
                                    List<string> l_headerTemplate = new List<string>();
                                    for(int i = 1; i < _templateExcel.Count; i++)
                                    {
                                        // Get Fist Row
                                        string header = sheetName.Cell(1, i).Value.ToString().Trim();
                                        var compapeHeader = _templateExcel.FirstOrDefault(x => x == header);

                                        if(compapeHeader != null)
                                        {
                                            l_headerTemplate.Add(header);
                                            isReadSuccess = true;
                                        }
                                        else
                                        {
                                            isReadSuccess = false;
                                            break;
                                        }
                                    }

                                    // Check Read Header Excel File
                                    if (isReadSuccess == false)
                                    {
                                        // Save Message Error
                                        _messageErrorDowload = Message.MessageCannotReadHeaderTemplate;
                                        // Reditrectoaction Page Notication Dowload Error
                                        return RedirectToAction("ErrorMessagePage", "Imports");
                                    }
                                    else
                                    {
                                        // Concat string
                                        string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventImportBooks);
                                        var cookies = Request.Cookies["LoginTDTImportKikanSystem"].ToString();
                                        // Get User And Role Request
                                        string[] inputData = request.Carshier.Split("*");

                                        var infoImport = new MainImportSystem();
                                        // Setting Base Info
                                        infoImport.Company = CommonEventCode.CompanyCode;
                                        infoImport.AreaCode = CommonEventCode.AreaCode;
                                        infoImport.StoreCode = CommonEventCode.StoreCode;
                                        infoImport.EventCode = eventCode;
                                        infoImport.Token = cookies;
                                        infoImport.UserID = inputData[0];
                                        infoImport.RoleID = inputData[1];


                                        switch (_typeImport)
                                        {
                                            case var item when item == EnumImportData.Excelimport_Books:
                                                // Books Import

                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                }
                            }

                        }
                    }
                    catch(Exception ex)
                    {
                        // Save Message Error
                        _messageErrorDowload = ex.Message;
                        // Reditrectoaction Page Notication Dowload Error
                        return RedirectToAction("ErrorMessagePage", "Imports");
                    }
                }
                else
                {
                    // Reditrectoaction Login Page
                    return RedirectToAction("Login", "SignIn");
                }

            }
        }

        /// <summary>
        /// Error Message Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ErrorMessagePage()
        {
            ViewBag.messageError = _messageErrorDowload;
            ViewBag.curentPage = _cutentPage;
            return View();
        }

    }
}
