using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.BoSystem;
using ConfigurationInterfaces.DataCommon;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Bo.AreaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApplycations.BoSystem
{
    public class AreaBO: IAreaBO
    {
        private readonly ContextFE context;
        private readonly IContactCommon contactCommon;
        public AreaBO(ContextFE _context, IContactCommon _contactCommon)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
        }

        /// <summary>
        /// SeachArea
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<M_ListArea> SeachArea(string request, string userID, string roleID, string token, string eventCode, string companyCode)
        {
            var result = new M_ListArea();
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
            return result;
        }
    }
}
