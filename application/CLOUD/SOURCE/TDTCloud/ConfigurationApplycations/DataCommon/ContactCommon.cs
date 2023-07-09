using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.DataCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApplycations.DataCommon
{
    public class ContactCommon : IContactCommon
    {
        private readonly ContextFE context;
        public ContactCommon(ContextFE _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// ValidationRoleUser
        /// </summary>
        /// <param name="role"></param>
        /// <param name="UserId"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationRoleUser(string role, string UserId, string eventCode)
        {
            throw new NotImplementedException();
        }


    }
}
