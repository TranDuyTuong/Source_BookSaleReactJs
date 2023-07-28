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
        /// /// <param name="Carshier"></param>
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
                    var result = await this.importData.GetTemplateByKikaSystemBook(jsonConver);
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
        /// Authors
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Authors(string Carshier)
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
                    string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventImportAuthor);
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
                        TypeImport = EnumImportData.Excelimport_Author,
                        UserID = inputData[0],
                        Role = inputData[1]

                    };
                    // Conver Object to Json
                    string jsonConver = CommonConverJsonToObject<TemplateImportKikanSystem>.CoverObjectToJson(dataInitia);
                    var result = await this.importData.GetTemplateByKikaSystemBook(jsonConver);
                    // Conver Json to Object
                    var InitData = CommonConverJsonToObject<TemplateImportKikanSystem>.ConverJsonToObject(result);

                    if (InitData == null)
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
                            _cutentPage = "Authors";

                            // Save Sheet Name
                            _sheetName = "Authors";

                            // Save Type Import
                            _typeImport = EnumImportData.Excelimport_Author;
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
        /// PublishingCompany
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> PublishingCompany(string Carshier)
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
                    string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventPublishingCompany);
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
                        TypeImport = EnumImportData.Excelimport_PublishingCompany,
                        UserID = inputData[0],
                        Role = inputData[1]

                    };
                    // Conver Object to Json
                    string jsonConver = CommonConverJsonToObject<TemplateImportKikanSystem>.CoverObjectToJson(dataInitia);
                    var result = await this.importData.GetTemplateByKikaSystemBook(jsonConver);
                    // Conver Json to Object
                    var InitData = CommonConverJsonToObject<TemplateImportKikanSystem>.ConverJsonToObject(result);

                    if (InitData == null)
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
                            _cutentPage = "PublishingCompany";

                            // Save Sheet Name
                            _sheetName = "PublishingCompany";

                            // Save Type Import
                            _typeImport = EnumImportData.Excelimport_PublishingCompany;
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
        /// Citys
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Citys(string Carshier)
        {
            return View();
        }

        /// <summary>
        /// Categorys
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Categorys(string Carshier)
        {
            return View();
        }

        /// <summary>
        /// Districts
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Districts(string Carshier)
        {
            return View();
        }

        /// <summary>
        /// BankSuports
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> BankSuports(string Carshier)
        {
            return View();
        }

        /// <summary>
        /// IssuingCompanys
        /// </summary>
        /// <param name="Carshier"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IssuingCompanys(string Carshier)
        {
            return View();
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

                                // Count Colums Excel
                                int count = 0;

                                // Create cell in file
                                for(int i = 0; i < _templateExcel.Count; i++) 
                                {
                                    count++;
                                    worksheet.Cell(1, count).Value = _templateExcel[i];
                                    worksheet.Cell(1, count).Style.Fill.BackgroundColor = XLColor.Yellow;
                                    worksheet.Cell(1, count).Style.Border.BottomBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, count).Style.Border.TopBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, count).Style.Border.LeftBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, count).Style.Border.RightBorder = XLBorderStyleValues.Double;
                                    worksheet.Cell(1, count).Style.Font.Bold = true;
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
                return new JsonResult(0);
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
                            return new JsonResult(1);
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
                                        return new JsonResult(1);
                                    }
                                    else
                                    {
                                        var cookies = Request.Cookies["LoginTDTImportKikanSystem"].ToString();
                                        // Get User And Role Request
                                        string[] inputData = request.Carshier.Split("*");

                                        var infoImport = new MainImportSystem();
                                        // Setting Base Info
                                        infoImport.Company = CommonEventCode.CompanyCode;
                                        infoImport.AreaCode = CommonEventCode.AreaCode;
                                        infoImport.StoreCode = CommonEventCode.StoreCode;
                                        infoImport.Token = cookies;
                                        infoImport.UserID = inputData[0];
                                        infoImport.RoleID = inputData[1];
                                        infoImport.TypeImport = _typeImport;

                                        switch (_typeImport)
                                        {
                                            // Books
                                            case var item when item == EnumImportData.Excelimport_Books:
                                                // Get File Name
                                                infoImport.FileName = CommonFileNameImports.ImportBooksKikanSystem;
                                                // Concat string
                                                string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventImportBooks);
                                                infoImport.EventCode = eventCode;

                                                // Get Row in excel
                                                for (int i = 2; i <= rowCount; i++)
                                                {
                                                    // If Data Null Break
                                                    var checkNull = sheetName.Cell(i, 1).Value.ToString().Trim();
                                                    if(checkNull == null || checkNull == "")
                                                    {
                                                        break;
                                                    }

                                                    // Get Data in Excel And Save Into List
                                                    var itemRow = new BooksImport()
                                                    {
                                                        ItemCode = sheetName.Cell(i, 1).Value.ToString().Trim(),
                                                        CompanyCode = sheetName.Cell(i, 2).Value.ToString().Trim(),
                                                        StoreCode = sheetName.Cell(i, 3).Value.ToString().Trim(),
                                                        ApplyDate = Convert.ToDateTime(sheetName.Cell(i, 4).Value.ToString().Trim()),
                                                        Description = sheetName.Cell(i, 5).Value.ToString().Trim(),
                                                        DescriptionShort = sheetName.Cell(i, 6).Value.ToString().Trim(),
                                                        DescriptionLong = sheetName.Cell(i, 7).Value.ToString().Trim(),
                                                        PriceOrigin = Convert.ToDecimal(sheetName.Cell(i, 8).Value.ToString().Trim()),
                                                        PercentDiscount = Convert.ToInt32(sheetName.Cell(i, 9).Value.ToString().Trim()),
                                                        priceSale = Convert.ToDecimal(sheetName.Cell(i, 10).Value.ToString().Trim()),
                                                        QuantityDiscountID = null,
                                                        PairDiscountID = null,
                                                        SpecialDiscountID = null,
                                                        Quantity = Convert.ToInt32(sheetName.Cell(i, 14).Value.ToString().Trim()),
                                                        Viewer = Convert.ToInt32(sheetName.Cell(i, 15).Value.ToString().Trim()),
                                                        Buy = Convert.ToInt32(sheetName.Cell(i, 16).Value.ToString().Trim()),
                                                        CategoryItemMasterID = sheetName.Cell(i, 17).Value.ToString().Trim(),
                                                        AuthorID = sheetName.Cell(i, 18).Value.ToString().Trim(),
                                                        DateCreate = Convert.ToDateTime(sheetName.Cell(i, 19).Value.ToString().Trim()),
                                                        IssuingCompanyID = sheetName.Cell(i, 20).Value.ToString().Trim(),
                                                        PublicationDate = Convert.ToDateTime(sheetName.Cell(i, 21).Value.ToString().Trim()),
                                                        size = sheetName.Cell(i, 22).Value.ToString().Trim(),
                                                        PageNumber = Convert.ToInt32(sheetName.Cell(i, 23).Value.ToString().Trim()),
                                                        PublishingCompanyID = sheetName.Cell(i, 24).Value.ToString().Trim(),
                                                        IsSale = Convert.ToBoolean(sheetName.Cell(i, 25).Value.ToString().Trim().ToUpper()),
                                                        LastUpdateDate = null,
                                                        Note = sheetName.Cell(i, 27).Value.ToString().Trim(),
                                                        HeadquartersLastUpdateDateTime = Convert.ToDateTime(sheetName.Cell(i, 28).Value.ToString().Trim()),
                                                        IsDeleteFlag = Convert.ToBoolean(sheetName.Cell(i, 29).Value.ToString().Trim().ToUpper()),
                                                        UserID = sheetName.Cell(i, 30).Value.ToString().Trim(),
                                                        TaxGroupCodeID = null
                                                    };
                                                    infoImport.listBooks.Add(itemRow);
                                                }
                                                break;

                                            // Author
                                            case var item when item == EnumImportData.Excelimport_Author:
                                                // Get File Name
                                                infoImport.FileName = CommonFileNameImports.ImportAuthorKikanSystem;
                                                // Concat string
                                                string eventCode1 = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventImportAuthor);
                                                infoImport.EventCode = eventCode1;

                                                // Get Row in excel
                                                for (int i = 2; i <= rowCount; i++)
                                                {
                                                    // If Data Null Break
                                                    var checkNull = sheetName.Cell(i, 1).Value.ToString().Trim();
                                                    if (checkNull == null || checkNull == "")
                                                    {
                                                        break;
                                                    }

                                                    // Get Data in Excel And Save Into List                                               
                                                    var itemRow = new AuthorsImport()
                                                    {
                                                        AuthorID = sheetName.Cell(i, 1).Value.ToString().Trim(),
                                                        NameAuthor = sheetName.Cell(i, 2).Value.ToString().Trim(),
                                                        Birthday = Convert.ToDateTime(sheetName.Cell(i, 3).Value.ToString().Trim()),
                                                        Hometown = sheetName.Cell(i, 4).Value.ToString().Trim(),
                                                        Description = sheetName.Cell(i, 5).Value.ToString().Trim(),
                                                        DateCreate = Convert.ToDateTime(sheetName.Cell(i, 6).Value.ToString().Trim()),
                                                        UserID = sheetName.Cell(i, 7).Value.ToString().Trim(),
                                                        HeadquartersLastUpdateDateTime = Convert.ToDateTime(sheetName.Cell(i, 8).Value.ToString().Trim()),
                                                        LasUpdateDate = null,
                                                        ContentLastUpdateDate = string.Empty,
                                                        TotalBook = Convert.ToInt32(sheetName.Cell(i, 11).Value.ToString().Trim()),
                                                        IsDeleteFlag = Convert.ToBoolean(sheetName.Cell(i, 12).Value.ToString().Trim().ToUpper()),
                                                    };
                                                    infoImport.listAuthor.Add(itemRow);
                                                }
                                                break;

                                            // PublishingCompany
                                            case var item when item == EnumImportData.Excelimport_PublishingCompany:
                                                // Get File Name
                                                infoImport.FileName = CommonFileNameImports.ImportPublishingCompanyKikanSystem;
                                                // Concat string
                                                string eventCode2 = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventPublishingCompany);
                                                infoImport.EventCode = eventCode2;

                                                // Get Row in excel
                                                for (int i = 2; i <= rowCount; i++)
                                                {
                                                    // If Data Null Break
                                                    var checkNull = sheetName.Cell(i, 1).Value.ToString().Trim();
                                                    if (checkNull == null || checkNull == "")
                                                    {
                                                        break;
                                                    }

                                                    // Get Data in Excel And Save Into List                                               
                                                    var itemRow = new PublishingCompanyImport()
                                                    {
                                                        PublishingCompanyID = sheetName.Cell(i, 1).Value.ToString().Trim(),
                                                        Description = sheetName.Cell(i, 2).Value.ToString().Trim(),
                                                        Address = sheetName.Cell(i, 3).Value.ToString().Trim(),
                                                        DateCraete = Convert.ToDateTime(sheetName.Cell(i, 4).Value.ToString().Trim()),
                                                        DateOfIncorporation = Convert.ToDateTime(sheetName.Cell(i, 5).Value.ToString().Trim()),
                                                        UserID = sheetName.Cell(i, 6).Value.ToString().Trim(),
                                                        HeadquartersLastUpdateDateTime = Convert.ToDateTime(sheetName.Cell(i, 7).Value.ToString().Trim()),
                                                        LasUpdateDate = null,
                                                        ContentLastUpdateDate = null,
                                                        IsDeleteFlag = Convert.ToBoolean(sheetName.Cell(i, 10).Value.ToString().Trim().ToUpper())
                                                    };
                                                    infoImport.listPublishingCompany.Add(itemRow);
                                                }
                                                break;

                                            // Citys
                                            case var item when item == EnumImportData.Excelimport_City:
                                                // Get File Name
                                                infoImport.FileName = CommonFileNameImports.ImportCityKikanSystem;
                                                // Concat string
                                                string eventCode3 = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventCity);
                                                infoImport.EventCode = eventCode3;

                                                // Get Row in excel
                                                for (int i = 2; i <= rowCount; i++)
                                                {
                                                    // If Data Null Break
                                                    var checkNull = sheetName.Cell(i, 1).Value.ToString().Trim();
                                                    if (checkNull == null || checkNull == "")
                                                    {
                                                        break;
                                                    }

                                                    // Get Data in Excel And Save Into List                                               
                                                    var itemRow = new CitysImport()
                                                    {
                                                        CityID = sheetName.Cell(i, 1).Value.ToString().Trim(),
                                                        Description = sheetName.Cell(i, 2).Value.ToString().Trim(),
                                                        AreaCode = sheetName.Cell(i, 3).Value.ToString().Trim(),
                                                        Symbol = sheetName.Cell(i, 4).Value.ToString().Trim(),
                                                        HeadquartersLastUpdateDateTime = Convert.ToDateTime(sheetName.Cell(i, 5).Value.ToString().Trim()),
                                                        UserID = sheetName.Cell(i, 6).Value.ToString().Trim(),
                                                        IsDeleteFlag = Convert.ToBoolean(sheetName.Cell(i, 7).Value.ToString().Trim().ToUpper())
                                                    };
                                                    infoImport.listCitys.Add(itemRow);
                                                }
                                                break;
                                            
                                            // Category
                                            case var item when item == EnumImportData.Excelimport_Category:
                                                // Get File Name
                                                infoImport.FileName = CommonFileNameImports.ImportCategoryKikanSystem;
                                                // Concat string
                                                string eventCode4 = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventCategory);
                                                infoImport.EventCode = eventCode4;

                                                // Get Row in excel
                                                for (int i = 2; i <= rowCount; i++)
                                                {
                                                    // If Data Null Break
                                                    var checkNull = sheetName.Cell(i, 1).Value.ToString().Trim();
                                                    if (checkNull == null || checkNull == "")
                                                    {
                                                        break;
                                                    }

                                                    // Get Data in Excel And Save Into List                                               
                                                    var itemRow = new CategorysImport()
                                                    {
                                                        CategoryItemMasterID = sheetName.Cell(i, 1).Value.ToString().Trim(),
                                                        Description = sheetName.Cell(i, 2).Value.ToString().Trim(),
                                                        DateCreate = Convert.ToDateTime(sheetName.Cell(i, 3).Value.ToString().Trim()),
                                                        UserID = sheetName.Cell(i, 4).Value.ToString().Trim(),
                                                        LastUpdateDate = null,
                                                        HeadquartersLastUpdateDateTime = Convert.ToDateTime(sheetName.Cell(i, 6).Value.ToString().Trim()),
                                                        ContentLastUpdateDate = null,
                                                        JobID = sheetName.Cell(i, 8).Value.ToString().Trim(),
                                                        IsDeleteFlag = Convert.ToBoolean(sheetName.Cell(i, 9).Value.ToString().Trim().ToUpper())
                                                    };
                                                    infoImport.listCategory.Add(itemRow);
                                                }
                                                break;
                                            
                                            // District
                                            case var item when item == EnumImportData.Excelimport_District:
                                                // Get File Name
                                                infoImport.FileName = CommonFileNameImports.ImportDistrictKikanSystem;
                                                // Concat string
                                                string eventCode5 = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventDistrict);
                                                infoImport.EventCode = eventCode5;

                                                // Get Row in excel
                                                for (int i = 2; i <= rowCount; i++)
                                                {
                                                    // If Data Null Break
                                                    var checkNull = sheetName.Cell(i, 1).Value.ToString().Trim();
                                                    if (checkNull == null || checkNull == "")
                                                    {
                                                        break;
                                                    }

                                                    // Get Data in Excel And Save Into List                                               
                                                    var itemRow = new DistrictsImport()
                                                    {
                                                        DistrictID = sheetName.Cell(i, 1).Value.ToString().Trim(),
                                                        CityID = sheetName.Cell(i, 2).Value.ToString().Trim(),
                                                        ApplyDate = Convert.ToDateTime(sheetName.Cell(i, 3).Value.ToString().Trim()),
                                                        Description = sheetName.Cell(i, 4).Value.ToString().Trim(),
                                                        Identifier = sheetName.Cell(i, 5).Value.ToString().Trim(),
                                                        DateCreate = Convert.ToDateTime(sheetName.Cell(i, 6).Value.ToString().Trim()),
                                                        PriceShip = Convert.ToDecimal(sheetName.Cell(i, 7).Value.ToString().Trim()),
                                                        PriceShipNew = null,
                                                        LasUpdateDate = null,
                                                        HeadquartersLastUpdateDateTime = Convert.ToDateTime(sheetName.Cell(i, 10).Value.ToString().Trim().ToUpper()),
                                                        UserID = sheetName.Cell(i, 11).Value.ToString().Trim(),
                                                        IsDeleteFlag = Convert.ToBoolean(sheetName.Cell(i, 12).Value.ToString().Trim().ToUpper())
                                                    };
                                                    infoImport.listDistrict.Add(itemRow);
                                                }
                                                break;

                                            case var item when item == EnumImportData.Excelimport_BankSuport:
                                                break;
                                            case var item when item == EnumImportData.Excelimport_IssuingCompanys:
                                                break;
                                            default:
                                                // Fail not find TypeImport
                                                // Save Message Error
                                                _messageErrorDowload = Message.MessageErroNotFindTypeImport;
                                                return new JsonResult(1);
                                        }

                                        // Conver Object to Json
                                        string jsonConver = CommonConverJsonToObject<MainImportSystem>.CoverObjectToJson(infoImport);
                                        // Call Api
                                        var result = await this.importData.ImportDataIntoKikaSystem(jsonConver);
                                        // Conver Json to Object 
                                        var resultConver = CommonConverJsonToObject<ReturnCommonApi>.ConverJsonToObject(result);
                                        return new JsonResult(resultConver);
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
                        return new JsonResult(1);
                    }
                }
                else
                {
                    // Reditrectoaction Login Page
                    return new JsonResult(0);
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
