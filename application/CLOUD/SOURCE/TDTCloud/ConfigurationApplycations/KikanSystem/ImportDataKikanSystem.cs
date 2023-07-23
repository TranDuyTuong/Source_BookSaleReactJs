using CodeFirtMigration.DataFE;
using CommonConfiguration.KikianSystemCommon;
using ConfigurationInterfaces.DataCommon;
using ConfigurationInterfaces.KikanSystem;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_KikanSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                            where (tm.IsDelete == false && tm.TypeId == EnumTypeImportCommon.Excelimport_Books)
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
                            result.TypeImport = EnumTypeImportCommon.Excelimport_Books;
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
    }
}
