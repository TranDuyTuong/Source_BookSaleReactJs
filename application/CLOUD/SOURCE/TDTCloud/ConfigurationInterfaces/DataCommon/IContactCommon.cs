using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.DataCommon
{
    public interface IContactCommon
    {
        /// <summary>
        /// ValidationRoleUser
        /// </summary>
        /// <param name="role"></param>
        /// <param name="UserId"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        bool ValidationRoleUser(string role, string UserId, string eventCode);
    }
}
