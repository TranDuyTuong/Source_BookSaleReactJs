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
            // check role
            var getRole = this.context.Roles.Where(x => x.RoleID == role).ToArray();

            if (getRole.Length <= 0) 
            {
                return false;
            }

            var getUser = this.context.userAccounts.FirstOrDefault(x => x.Email == UserId);

            if (getUser == null)
            {
                return false;
            }

            // check user role
            var checkUserRole = this.context.userRoles.Where(x => x.RoleID == role && 
                                                                x.UserID == UserId && 
                                                                    x.EventCodeLimit == eventCode).ToArray();
            
            if(checkUserRole.Any()) 
            { 
                return true;
            }

            return false;

        }


    }
}
