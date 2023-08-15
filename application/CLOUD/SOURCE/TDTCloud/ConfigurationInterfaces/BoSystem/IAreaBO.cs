using ModelConfiguration.M_Bo.AreaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.BoSystem
{
    public interface IAreaBO
    {
        /// <summary>
        /// SeachArea
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListArea> SeachArea(string request, string userID, string roleID, string token, string eventCode, string companyCode);
    }
}
