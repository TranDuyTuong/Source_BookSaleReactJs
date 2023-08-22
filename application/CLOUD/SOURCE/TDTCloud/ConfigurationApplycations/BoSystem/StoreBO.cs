using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.BoSystem;
using ConfigurationInterfaces.DataCommon;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Bo.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApplycations.BoSystem
{
    public class StoreBO : IStoreBO
    {
        private readonly ContextFE context;
        private readonly IContactCommon contactCommon;
        public StoreBO(ContextFE _context, IContactCommon _contactCommon)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
        }

        /// <summary>
        /// ConfirmStore
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<M_ListStore> ConfirmStore(M_ListStore request)
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
                        // Choose Option For Comfirm Store DB
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

        /// <summary>
        /// DetailStore
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <param name="token"></param>
        /// <param name="eventCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public async Task<M_ListStore> DetailStore(string request, string userID, string roleID, string token, string eventCode, string companyCode)
        {
            var result = new M_ListStore();
            try
            {
                // Check CompanyCode
                bool isCompanyCode = this.contactCommon.ValidationCompanyCode(companyCode);

                if (isCompanyCode == true)
                {
                    // Check Role User Handle
                    bool isRole = this.contactCommon.ValidationRoleUserLimit(roleID, userID, eventCode);

                    if (isRole == true)
                    {
                        // Don't have role handle
                        result.Token = token;
                        result.UserID = userID;
                        result.RoleID = roleID;
                        result.EventCode = eventCode;
                        result.TotalStore = 0;
                        result.KeySeach = request;
                        result.CompanyCode = companyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get all store don't Delete
                        List<M_Store> ListStore = new List<M_Store>();
                        var queryStore = await this.context.stores.FirstOrDefaultAsync(x => x.IsDeleteFlag == false && x.StoreCode == request);

                        if (queryStore != null)
                        {
                            var store = new M_Store()
                            {
                                StoreCode = queryStore.StoreCode,
                                Description = queryStore.Description,
                                DateCreate = queryStore.DateCreate,
                                LastUpdateDate = queryStore.LastUpdateDate,
                                Address = queryStore.Address,
                                TypeOf = null,
                                OldType = null
                            };
                            ListStore.Add(store);

                            // setting result
                            result.Token = token;
                            result.UserID = userID;
                            result.RoleID = roleID;
                            result.EventCode = eventCode;
                            result.KeySeach = request;
                            result.CompanyCode = companyCode;
                            result.TotalStore = 1;
                            result.Status = true;
                            result.MessageError = null;
                            result.ListStore = ListStore;
                        }
                        else
                        {
                            // Not Find data
                            result.Token = token;
                            result.UserID = userID;
                            result.RoleID = roleID;
                            result.EventCode = eventCode;
                            result.KeySeach = request;
                            result.CompanyCode = companyCode;
                            result.TotalStore = 0;
                            result.Status = false;
                            result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                        }
                    }
                }
                else
                {
                    // Don't Find CompanyCode
                    result.Token = token;
                    result.UserID = userID;
                    result.RoleID = roleID;
                    result.EventCode = eventCode;
                    result.KeySeach = request;
                    result.CompanyCode = companyCode;
                    result.TotalStore = 0;
                    result.Status = false;
                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindCompanyCode;

                }
            }
            catch (Exception ex)
            {
                result.Token = token;
                result.UserID = userID;
                result.RoleID = roleID;
                result.EventCode = eventCode;
                result.KeySeach = request;
                result.CompanyCode = companyCode;
                result.TotalStore = 0;
                result.Status = false;
                result.MessageError = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// SeachStore
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <param name="token"></param>
        /// <param name="eventCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_ListStore> SeachStore(string request, string userID, string roleID, string token, string eventCode, string companyCode)
        {
            var result = new M_ListStore();
            try
            {
                // Check CompanyCode
                bool isCompanyCode = this.contactCommon.ValidationCompanyCode(companyCode);

                if (isCompanyCode == true)
                {
                    // Check Role User Handle
                    bool isRole = this.contactCommon.ValidationRoleUserLimit(roleID, userID, eventCode);

                    if (isRole == true)
                    {
                        // Don't have role handle
                        result.Token = token;
                        result.UserID = userID;
                        result.RoleID = roleID;
                        result.EventCode = eventCode;
                        result.TotalStore = 0;
                        result.KeySeach = request;
                        result.CompanyCode = companyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get all store don't Delete
                        List<M_Store> ListStore = new List<M_Store>();
                        var queryStore = await this.context.stores.Where(x => x.IsDeleteFlag == false).ToArrayAsync();

                        if (queryStore.Any() == true)
                        {
                            if (request == null || request == "")
                            {
                                if (queryStore.Length > CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    //more than 100, Take 100 recol
                                    var getRecol = queryStore.OrderByDescending(x => x.StoreCode).Take(CommonConfiguration.DataCommon.MaxRecol);

                                    foreach (var item in getRecol)
                                    {
                                        var storeItem = new M_Store()
                                        {
                                            StoreCode = item.StoreCode,
                                            Description = item.Description,
                                            DateCreate = item.DateCreate,
                                            LastUpdateDate = item.LastUpdateDate,
                                            Address = item.Address,
                                            TypeOf = null,
                                            OldType = null,
                                        };
                                        ListStore.Add(storeItem);
                                    }
                                    result.TotalStore = queryStore.Count();
                                    result.Status = true;
                                    result.MessageError = null;
                                }
                                else
                                {
                                    // Small Than 100 recol
                                    foreach (var item in queryStore)
                                    {
                                        var storeItem = new M_Store()
                                        {
                                            StoreCode = item.StoreCode,
                                            Description = item.Description,
                                            DateCreate = item.DateCreate,
                                            LastUpdateDate = item.LastUpdateDate,
                                            Address = item.Address,
                                            TypeOf = null,
                                            OldType = null,
                                        };
                                        ListStore.Add(storeItem);
                                    }
                                    result.TotalStore = 0;
                                    result.Status = true;
                                    result.MessageError = null;
                                }
                            }
                            else
                            {
                                var findStore = queryStore.FirstOrDefault(x => x.StoreCode == request);

                                if (findStore == null)
                                {
                                    // Not find Store
                                    result.TotalStore = 0;
                                    result.Status = false;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                                }
                                else
                                {
                                    // Have Store
                                    var storeItem = new M_Store()
                                    {
                                        StoreCode = findStore.StoreCode,
                                        Description = findStore.Description,
                                        DateCreate = findStore.DateCreate,
                                        LastUpdateDate = findStore.LastUpdateDate,
                                        Address = findStore.Address,
                                        TypeOf = null,
                                        OldType = null,
                                    };
                                    result.TotalStore = 0;
                                    result.Status = true;
                                    result.MessageError = null;
                                    ListStore.Add(storeItem);
                                }
                            }
                            // Find data
                            result.Token = token;
                            result.UserID = userID;
                            result.RoleID = roleID;
                            result.EventCode = eventCode;
                            result.KeySeach = request;
                            result.CompanyCode = companyCode;
                            result.ListStore = ListStore;
                        }
                        else
                        {
                            // Not Find data in DB
                            result.Token = token;
                            result.UserID = userID;
                            result.RoleID = roleID;
                            result.EventCode = eventCode;
                            result.KeySeach = request;
                            result.CompanyCode = companyCode;
                            result.TotalStore = 0;
                            result.Status = false;
                            result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                        }
                    }
                }
                else
                {
                    // Don't Find CompanyCode
                    result.Token = token;
                    result.UserID = userID;
                    result.RoleID = roleID;
                    result.EventCode = eventCode;
                    result.KeySeach = request;
                    result.CompanyCode = companyCode;
                    result.TotalStore = 0;
                    result.Status = false;
                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindCompanyCode;

                }
            }
            catch (Exception ex)
            {
                result.Token = token;
                result.UserID = userID;
                result.RoleID = roleID;
                result.EventCode = eventCode;
                result.KeySeach = request;
                result.CompanyCode = companyCode;
                result.TotalStore = 0;
                result.Status = false;
                result.MessageError = ex.Message;
            }
            return result;
        }
    }
}
