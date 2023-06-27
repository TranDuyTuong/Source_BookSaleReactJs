using ModelConfiguration.M_Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.User
{
    public interface IUserConfiguration
    {
        /// <summary>
        /// function login AuthorzirationUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ReturnLoginApi> AuthorzirationUser(LoginUser request);
    }
}
