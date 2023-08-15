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
        public async Task<M_ListArea> SeachArea(string request, string userID, string roleID, string token, string eventCode)
        {
            var result = new M_ListArea();
            // Check Role User Handle
            bool isRole = this.contactCommon.ValidationRoleUserLimit(roleID, userID, eventCode);
            
            if(isRole == true)
            {
                // Don't have role handle
                result.Status = false;
            }
            else
            {
                // Get all area
                List<M_Area> ListArea = new List<M_Area>();
                var queryArea = await this.context.areaMasters.ToArrayAsync();

                if (queryArea.Any() == true)
                {
                    if(request == null || request == "" || request == string.Empty)
                    {
                        // Get 100 recod Area in DB
                        if(queryArea.Count() > CommonConfiguration.DataCommon.MaxRecol)
                        {
                            // More Than 100
                            var take100Recol = queryArea.Take(CommonConfiguration.DataCommon.MaxRecol);
                            foreach(var item in take100Recol)
                            {
                                var area = new M_Area()
                                {
                                    CompanyCode = item.CompanyCode,
                                    AreaCode = item.AreaCode,
                                    Description = item.Description
                                };
                                ListArea.Add(area);
                            }
                            result.Status = true;
                            result.TotalArea = queryArea.Count();
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
                        }
                    }

                }
            }
            throw new NotImplementedException();
        }
    }
}
