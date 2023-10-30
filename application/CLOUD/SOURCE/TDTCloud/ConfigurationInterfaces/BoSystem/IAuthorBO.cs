using ModelConfiguration.M_Bo.AreaData;
using ModelConfiguration.M_Bo.AuthorData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.BoSystem
{
    public interface IAuthorBO
    {
        /// <summary>
        /// SeachArea
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <param name="token"></param>
        /// <param name="eventCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        Task<M_ListAuthor> SeachAuthor(string request, string userID, string roleID, string token, string eventCode, string companyCode);
    }
}
