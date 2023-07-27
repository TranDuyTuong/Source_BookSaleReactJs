using CodeFirtMigration.DataFE;
using CommonConfiguration.KikianSystemCommon;
using ConfigurationInterfaces.DataCommon;
using ConfigurationInterfaces.KikanSystem;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Common;
using ModelConfiguration.M_KikanSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace ConfigurationApplycations.KikanSystem
{
    public class ImportDataKikanSystem : IimportDataKikanSystem
    {
        private readonly ContextFE context;
        private readonly IContactCommon contactCommon;
        public ImportDataKikanSystem(ContextFE _context, IContactCommon _contactCommon)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
        }

        /// <summary>
        /// GetTemplateImport
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TemplateImportKikanSystem> GetTemplateImport(TemplateImportKikanSystem request)
        {
            var result = new TemplateImportKikanSystem();
            try
            {
                // Check Base Infomation
                bool checkBaseInfo = await this.ValidationInfoBase(request.Company, request.AreaCode, request.StoreCode);

                if (!checkBaseInfo)
                {
                    result.Status = false;
                    result.EventCode = CommonConfiguration.DataCommon.EventError;
                    result.MessageErroe = CommonConfiguration.DataCommon.MessageBaseInfo;
                }
                else
                {
                    // Check Role User
                    bool checkUserRole = this.contactCommon.ValidationRoleUserLimit(request.Role, request.UserID, request.EventCode);

                    if (checkUserRole)
                    {
                        result.Status = false;
                        result.EventCode = CommonConfiguration.DataCommon.EventError;
                        result.MessageErroe = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get Template By TypeId
                        var queryTemplate = from tm in this.context.templateImports
                                            where (tm.IsDelete == false && tm.TypeId == request.TypeImport)
                                            select tm;

                        // Check result query
                        if (queryTemplate.Count() == 0)
                        {
                            // Not find template by TypeID
                            result.Status = false;
                            result.EventCode = CommonConfiguration.DataCommon.EventError;
                            result.MessageErroe = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon.MessageError;
                        }
                        else
                        {
                            // Find template by TypeId
                            result.Status = true;
                            result.EventCode = CommonConfiguration.DataCommon.EventSuccess;
                            result.TypeImport = request.TypeImport;
                            result.Company = request.Company;
                            result.StoreCode = request.StoreCode;
                            result.AreaCode = request.AreaCode;
                            request.UserID = request.UserID;
                            request.Role = request.Role;
                            request.Token = request.Token;

                            // Get TemplateResult
                            foreach (var item in queryTemplate)
                            {
                                result.ContentTemplate = item.Content;
                                result.NameFile = item.Description;
                            }
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                result.Status = false;
                result.EventCode = CommonConfiguration.DataCommon.EventError;
                result.MessageErroe = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// ImportDataIntoSystem
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ReturnCommonApi> ImportDataIntoSystem(MainImportSystem request)
        {
            var result = new ReturnCommonApi();
            try
            {
                // Check Base Infomation
                bool checkBaseInfo = await this.ValidationInfoBase(request.Company, request.AreaCode, request.StoreCode);

                if (!checkBaseInfo)
                {
                    // Check Fail
                    result.Status = false;
                    result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                    result.Message = CommonConfiguration.DataCommon.MessageBaseInfo;
                }
                else
                {
                    // Check Role User
                    bool checkUserRole = this.contactCommon.ValidationRoleUserLimit(request.RoleID, request.UserID, request.EventCode);

                    if (checkUserRole)
                    {
                        // Check Fail
                        result.Status = false;
                        result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                        result.Message = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Validation File Name Import
                        bool checkFileName = this.ValidationFileNameImport(request.FileName);

                        if (!checkFileName)
                        {
                            result.Status = false;
                            result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                            result.Message = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon
                                                .MessageNotFindFileName;
                        }
                        else
                        {
                            DateTime curentDate = DateTime.Now;
                            // Select Type Import
                            switch (request.TypeImport)
                            {
                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_Books:
                                    // Get All item in DB
                                    var queryItemMaster = await this.context.itemMasters.ToArrayAsync();
                                    // List Save Item Master Import
                                    List<ItemMaster> listMaster = new List<ItemMaster>();

                                    foreach (var book in request.listBooks)
                                    {
                                        // Check Applydate must more than current date 
                                        if (book.ApplyDate <= curentDate)
                                        {
                                            result.Status = false;
                                            result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                                            result.Message = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon
                                                                .MessageApplydateError + " " + "(" + book.ItemCode + ")";
                                            break;
                                        }

                                        // Check ItemCode and Applydate
                                        var findItem = queryItemMaster.Where(x => x.ItemCode == book.ItemCode
                                                                            && x.ApplyDate == book.ApplyDate).ToArray();

                                        if (findItem.Any())
                                        {
                                            // Duplicate Data
                                            result.Status = false;
                                            result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                                            result.Message = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon
                                                                .MessageDuplicateData + " " + "(" + book.ItemCode + "-" + book.ApplyDate + ")";
                                            break;
                                        }
                                        else
                                        {
                                            var bookItem = new ItemMaster()
                                            {
                                                CompanyCode = book.CompanyCode,
                                                StoreCode = book.StoreCode,
                                                ItemCode = book.ItemCode,
                                                ApplyDate = book.ApplyDate,
                                                Description = book.Description,
                                                DescriptionShort = book.DescriptionShort,
                                                DescriptionLong = book.DescriptionLong,
                                                PriceOrigin = book.PriceOrigin,
                                                PercentDiscount = book.PercentDiscount,
                                                priceSale = book.priceSale,
                                                QuantityDiscountID = book.QuantityDiscountID,
                                                PairDiscountID = book.PairDiscountID,
                                                SpecialDiscountID = book.SpecialDiscountID,
                                                Quantity = book.Quantity,
                                                Viewer = book.Viewer,
                                                Buy = book.Buy,
                                                CategoryItemMasterID = book.CategoryItemMasterID,
                                                AuthorID = book.AuthorID,
                                                DateCreate = book.DateCreate,
                                                IssuingCompanyID = book.IssuingCompanyID,
                                                PublicationDate = book.PublicationDate,
                                                size = book.size,
                                                PageNumber = book.PageNumber,
                                                PublishingCompanyID = book.PublishingCompanyID,
                                                IsSale = book.IsSale,
                                                LastUpdateDate = book.LastUpdateDate,
                                                Note = book.Note,
                                                HeadquartersLastUpdateDateTime = book.HeadquartersLastUpdateDateTime,
                                                IsDeleteFlag = book.IsDeleteFlag,
                                                UserID = book.UserID,
                                                TaxGroupCodeID = book.TaxGroupCodeID
                                            };
                                            listMaster.Add(bookItem);
                                        }
                                        result.Status = true;
                                    }

                                    if (result.Status != false)
                                    {
                                        // Save In DB
                                        await this.context.itemMasters.AddRangeAsync(listMaster);
                                        // Save Log
                                        var logger = new Log()
                                        {
                                            Id = new Guid(),
                                            UserID = request.UserID,
                                            DateCreate = DateTime.Now,
                                            Message = "Import Book Into System By KikanSystem, " + listMaster.Count + "Row",
                                            Status = true
                                        };
                                        await this.context.logs.AddAsync(logger);
                                        // Success Import
                                        result.Status = true;
                                        result.IdPlugin = CommonConfiguration.DataCommon.EventSuccess;
                                        result.Message = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon
                                                            .MessageImportSuccess + " " + listMaster.Count + " " + " Row";
                                    }
                                    break;

                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_Author:
                                    // Get All item in DB
                                    var queryAuthor = await this.context.authors.ToArrayAsync();
                                    // List Save Author Import
                                    List<Author> listAuthor = new List<Author>();

                                    foreach (var author in request.listAuthor)
                                    {
                                        // Check ItemCode and Applydate
                                        var findItem = queryAuthor.Where(x => x.AuthorID == author.AuthorID).ToArray();

                                        if (findItem.Any())
                                        {
                                            // Duplicate Data
                                            result.Status = false;
                                            result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                                            result.Message = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon
                                                                .MessageDuplicateData + " " + "(" + author.AuthorID + ")";
                                            break;
                                        }
                                        else
                                        {
                                            var authorItem = new Author()
                                            {
                                                AuthorID = author.AuthorID,
                                                NameAuthor = author.NameAuthor,
                                                Birthday = author.Birthday,
                                                Hometown = author.Hometown,
                                                Description = author.Description,
                                                DateCreate = author.DateCreate,
                                                UserID = author.UserID,
                                                HeadquartersLastUpdateDateTime = author.HeadquartersLastUpdateDateTime,
                                                LastUpdateDate = author.LasUpdateDate,
                                                ContentLastUpdateDate = author.ContentLastUpdateDate,
                                                TotalBook = author.TotalBook,
                                                IsDeleteFlag = author.IsDeleteFlag,
                                            };
                                            listAuthor.Add(authorItem);
                                        }
                                        result.Status = true;
                                    }

                                    if (result.Status != false)
                                    {
                                        // Save In DB
                                        await this.context.authors.AddRangeAsync(listAuthor);
                                        // Save Log
                                        var logger = new Log()
                                        {
                                            Id = new Guid(),
                                            UserID = request.UserID,
                                            DateCreate = DateTime.Now,
                                            Message = "Import Book Into System By KikanSystem, " + listAuthor.Count + "Row",
                                            Status = true
                                        };
                                        await this.context.logs.AddAsync(logger);
                                        // Success Import
                                        result.Status = true;
                                        result.IdPlugin = CommonConfiguration.DataCommon.EventSuccess;
                                        result.Message = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon
                                                            .MessageImportSuccess + " " + listAuthor.Count + " " + " Row";
                                    }
                                    break;
                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_PublishingCompany:
                                    break;
                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_City:
                                    break;
                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_Category:
                                    break;
                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_District:
                                    break;
                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_BankSuport:
                                    break;
                                case var item when item == CommonConfiguration.KikianSystemCommon.EnumTypeImportCommon.Excelimport_IssuingCompanys:
                                    break;
                                default:
                                    result.Status = false;
                                    result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                                    result.Message = CommonConfiguration.KikianSystemCommon.MessageNotificationKikanSystemCommon
                                                        .MessageNotFindTypeImport;
                                    break;
                            }
                            await this.context.SaveChangesAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// ValidationInfoBase
        /// </summary>
        /// <param name="company"></param>
        /// <param name="area"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        private async Task<bool> ValidationInfoBase(string company, string area, string store)
        {
            var result = true;
            // Check Company and Area
            var queryCompanyArea = await this.context.areaMasters
                                    .FirstOrDefaultAsync(x => x.CompanyCode == company && x.AreaCode == area);
            // Check Store
            var queryStore = await this.context.stores.FirstOrDefaultAsync(x => x.StoreCode == store);

            if (queryCompanyArea == null || queryStore == null)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// ValidationFileNameImport
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool ValidationFileNameImport(string fileName)
        {
            bool result = true;
            // Get file Name In DB
            var queryFileName = this.context.templateImports.Where(x => x.Description == fileName).ToArray();

            if (queryFileName.Any())
            {
                // Get In Local File
                switch (fileName)
                {
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportBooksKikanSystem:
                        result = true;
                        break;
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportAuthorKikanSystem:
                        result = true;
                        break;
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportPublishingCompanyKikanSystem:
                        result = true;
                        break;
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportCityKikanSystem:
                        result = true;
                        break;
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportCategoryKikanSystem:
                        result = true;
                        break;
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportDistrictKikanSystem:
                        result = true;
                        break;
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportBankSuportKikanSystem:
                        result = true;
                        break;
                    case var item when item == CommonConfiguration.KikianSystemCommon.FileNameImportCommon.ImportIssuingCompanysCompanyKikanSystem:
                        result = true;
                        break;
                    default:
                        result = false;
                        break;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

    }
}
