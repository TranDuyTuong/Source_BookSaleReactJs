using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.BoSystem;
using ConfigurationInterfaces.DataCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ModelConfiguration.M_Bo.AreaData;
using ModelConfiguration.M_Bo.StoreData;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace ConfigurationApplycations.BoSystem
{
    public class AreaBO : IAreaBO
    {
        private readonly ContextFE context;
        private readonly IContactCommon contactCommon;
        public AreaBO(ContextFE _context, IContactCommon _contactCommon)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
        }

        /// <summary>
        /// ConfirmArea
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_ListArea> ConfirmArea(M_ListArea request)
        {
            var result = new M_ListArea();
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
                        result.TotalArea = 0;
                        result.KeySeach = null;
                        result.CompanyCode = request.CompanyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Choose Option For Comfirm Area
                        var queryArea = await this.context.areaMasters.Where(x => x.CompanyCode == request.CompanyCode).ToArrayAsync();

                        if (queryArea.Any() == true)
                        {
                            // Update Data Into DB
                            foreach (var item in request.ListArea)
                            {
                                switch (item.TypeOf)
                                {
                                    // Create
                                    case var typeOf when typeOf == CommonConfiguration.DataCommon.CREATE:
                                        var createArea = new AreaMaster()
                                        {
                                            CompanyCode = request.CompanyCode,
                                            AreaCode = item.AreaCode,
                                            Description = item.Description
                                        };
                                        await this.context.areaMasters.AddAsync(createArea);

                                        // Save Log
                                        var logCreate = new Log()
                                        {
                                            Id = new Guid(),
                                            UserID = request.UserID,
                                            Message = "Create Area, AreaCode is: " + item.AreaCode,
                                            DateCreate = DateTime.Now,
                                            Status = true
                                        };
                                        await this.context.logs.AddAsync(logCreate);
                                        break;
                                    // Update
                                    case var typeOf when typeOf == CommonConfiguration.DataCommon.UPDATE:
                                        var updateArea = queryArea.FirstOrDefault(x => x.AreaCode == item.AreaCode);

                                        if (updateArea != null)
                                        {
                                            // Update Area
                                            updateArea.Description = item.Description;
                                            this.context.areaMasters.Update(updateArea);

                                            // Save Log
                                            var logUpdate = new Log()
                                            {
                                                Id = new Guid(),
                                                UserID = request.UserID,
                                                Message = "Update Area, AreaCode is: " + item.AreaCode + ", Content Update " + item.Description,
                                                DateCreate = DateTime.Now,
                                                Status = true
                                            };
                                            await this.context.logs.AddAsync(logUpdate);
                                        }
                                        else
                                        {
                                            // Create Area In Update
                                            var createAreaInUpdate = new AreaMaster()
                                            {
                                                CompanyCode = item.CompanyCode,
                                                AreaCode = item.AreaCode,
                                                Description = item.Description
                                            };
                                            await this.context.areaMasters.AddAsync(createAreaInUpdate);

                                            // Save Log
                                            var logCreateInUpdate = new Log()
                                            {
                                                Id = new Guid(),
                                                UserID = request.UserID,
                                                Message = "Create Area, AreaCode is: " + item.AreaCode,
                                                DateCreate = DateTime.Now,
                                                Status = true
                                            };
                                            await this.context.logs.AddAsync(logCreateInUpdate);
                                        }
                                        break;
                                    // Delete
                                    case var typeOf when typeOf == CommonConfiguration.DataCommon.DELETE:
                                        var deleteArea = queryArea.FirstOrDefault(x => x.AreaCode == item.AreaCode);

                                        if (deleteArea != null)
                                        {
                                            this.context.areaMasters.Remove(deleteArea);

                                            // Save Log
                                            var logDelete = new Log()
                                            {
                                                Id = new Guid(),
                                                UserID = request.UserID,
                                                Message = "Delete Area, AreaCode is: " + item.AreaCode,
                                                DateCreate = DateTime.Now,
                                                Status = true
                                            };
                                            await this.context.logs.AddAsync(logDelete);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            await this.context.SaveChangesAsync();
                            // Success 
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalArea = 0;
                            result.KeySeach = null;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = true;
                            result.MessageError = null;
                        }
                        else
                        {
                            // Not Find data
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalArea = 0;
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
                    result.TotalArea = 0;
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
                result.TotalArea = 0;
                result.KeySeach = null;
                result.CompanyCode = request.CompanyCode;
                result.Status = false;
                result.MessageError = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// SeachArea
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<M_ListArea> SeachArea(string request, string userID, string roleID, string token, string eventCode, string companyCode)
        {
            var result = new M_ListArea();
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
                        result.TotalArea = 0;
                        result.KeySeach = request;
                        result.CompanyCode = companyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get all area
                        List<M_Area> ListArea = new List<M_Area>();
                        var queryArea = await this.context.areaMasters.Where(x => x.CompanyCode == companyCode).ToArrayAsync();

                        if (queryArea.Any() == true)
                        {
                            // Update Data Into DB
                            if (request == null || request == "" || request == string.Empty)
                            {
                                // Get 100 recod Area in DB
                                if (queryArea.Count() > CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    // More Than 100
                                    var take100Recol = queryArea.Take(CommonConfiguration.DataCommon.MaxRecol);
                                    foreach (var item in take100Recol)
                                    {
                                        var area = new M_Area()
                                        {
                                            CompanyCode = item.CompanyCode,
                                            AreaCode = item.AreaCode,
                                            Description = item.Description
                                        };
                                        ListArea.Add(area);
                                    }
                                    result.Token = token;
                                    result.UserID = userID;
                                    result.RoleID = roleID;
                                    result.EventCode = eventCode;
                                    result.KeySeach = request;
                                    result.CompanyCode = companyCode;
                                    result.Status = true;
                                    result.TotalArea = queryArea.Count();
                                    result.MessageError = CommonConfiguration.DataCommon.MessageErrorMoreThan100Recol;
                                }
                                else
                                {
                                    // Less Than 100
                                    foreach (var item in queryArea)
                                    {
                                        var area = new M_Area()
                                        {
                                            CompanyCode = item.CompanyCode,
                                            AreaCode = item.AreaCode,
                                            Description = item.Description
                                        };
                                        ListArea.Add(area);
                                    }
                                    result.Token = token;
                                    result.UserID = userID;
                                    result.RoleID = roleID;
                                    result.EventCode = eventCode;
                                    result.KeySeach = request;
                                    result.CompanyCode = companyCode;
                                    result.TotalArea = 0;
                                    result.Status = true;
                                }
                            }
                            else
                            {
                                // Seach areaCode
                                var seachArea = queryArea.FirstOrDefault(x => x.AreaCode == request);

                                if (seachArea != null)
                                {
                                    // Find data by seach
                                    var area = new M_Area()
                                    {
                                        CompanyCode = seachArea.CompanyCode,
                                        AreaCode = seachArea.AreaCode,
                                        Description = seachArea.Description
                                    };
                                    ListArea.Add(area);

                                    result.Token = token;
                                    result.UserID = userID;
                                    result.RoleID = roleID;
                                    result.EventCode = eventCode;
                                    result.KeySeach = request;
                                    result.CompanyCode = companyCode;
                                    result.TotalArea = 0;
                                    result.Status = true;
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
                                    result.TotalArea = 0;
                                    result.Status = false;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                                }
                            }
                            result.ListArea = ListArea;
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
                            result.TotalArea = 0;
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
                    result.TotalArea = 0;
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
                result.TotalArea = 0;
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

                                if(findStore == null)
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
