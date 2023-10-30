using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.BoSystem;
using ConfigurationInterfaces.DataCommon;
using ModelConfiguration.M_Bo.AuthorData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApplycations.BoSystem
{
    public class AuthorBO : IAuthorBO
    {
        private readonly ContextFE context;
        private readonly IContactCommon contactCommon;
        public AuthorBO(ContextFE _context, IContactCommon _contactCommon)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
        }

        /// <summary>
        /// SeachAuthor
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <param name="token"></param>
        /// <param name="eventCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<M_ListAuthor> SeachAuthor(string request, string userID, string roleID, string token, string eventCode, string companyCode)
        {
            throw new NotImplementedException();
        }
    }
}
