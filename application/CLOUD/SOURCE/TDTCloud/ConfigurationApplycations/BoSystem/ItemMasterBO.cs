using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.BoSystem;
using ConfigurationInterfaces.DataCommon;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Bo.ItemMasterData;
using ModelConfiguration.M_Bo.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace ConfigurationApplycations.BoSystem
{
    public class ItemMasterBO : IitemMasterBO
    {
        private readonly ContextFE context;
        private readonly IContactCommon contactCommon;
        public ItemMasterBO(ContextFE _context, IContactCommon _contactCommon)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
        }

        /// <summary>
        /// InitializaItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_ListStore> InitializaItemMaster(InitializaDataMaters request)
        {
            var result = new M_ListStore();
            try
            {
                // Check CompanyCode
                bool isCompanyCode = this.contactCommon.ValidationCompanyCode(request.CompanyCode);

                if (isCompanyCode == true)
                {
                    // Check Role User Handle
                    bool isRole = this.contactCommon.ValidationRoleUserLimit(request.RoleID, request.UserID, request.EventCode);

                    if (isRole == true)
                    {
                        // Don't have role handle
                        result.Token = request.Token;
                        result.UserID = request.UserID;
                        result.RoleID = request.RoleID;
                        result.EventCode = request.EventCode;
                        result.TotalStore = 0;
                        result.KeySeach = null;
                        result.CompanyCode = request.CompanyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get All Store in DB
                        var queryStore = await this.context.stores.Where(x => x.IsDeleteFlag == false).ToArrayAsync();

                        if(queryStore.Any() == true)
                        {
                            List<M_Store> storeList = new List<M_Store>();

                            foreach (var store in queryStore)
                            {
                                var storeItem = new M_Store()
                                {
                                    StoreCode = store.StoreCode,
                                    Description = store.Description,                                  
                                };
                                storeList.Add(storeItem);
                            }

                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalStore = 0;
                            result.KeySeach = null;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = true;
                            result.MessageError = null;
                            result.ListStore = storeList;
                        }
                        else
                        {
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalStore = 0;
                            result.KeySeach = null;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = false;
                            result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                        }
                    }
                }
                else
                {
                    // Don't Find CompanyCode
                    result.Token = request.Token;
                    result.UserID = request.UserID;
                    result.RoleID = request.RoleID;
                    result.EventCode = request.EventCode;
                    result.TotalStore = 0;
                    result.KeySeach = null;
                    result.CompanyCode = request.CompanyCode;
                    result.Status = false;
                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindCompanyCode;

                }
            }
            catch (Exception ex)
            {
                result.Token = request.Token;
                result.UserID = request.UserID;
                result.RoleID = request.RoleID;
                result.EventCode = request.EventCode;
                result.TotalStore = 0;
                result.KeySeach = null;
                result.CompanyCode = request.CompanyCode;
                result.Status = false;
                result.MessageError = ex.Message;
            }
            return result;
        }

    }
}
