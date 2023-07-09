using ConfigurationInterfaces.DataCommon;
using ModelConfiguration.M_Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonConfiguration
{
    public class ValidationToken
    {
        private readonly IContactCommon context;
        public ValidationToken(IContactCommon _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// ReadContentToken
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ReturnCommonApi ReadContentToken(string token, string eventcode)
        {
            var result = new ReturnCommonApi();
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokens = jsonToken as JwtSecurityToken;
            return result;
        }

        /// <summary>
        /// CheckRoleUser
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CheckRoleUser(string roleId, string userId, string eventCode)
        {
            var result = this.context.ValidationRoleUser(roleId, userId, eventCode);
            return true;
        }


        /// <summary>
        /// CheckDateTimeToken
        /// </summary>
        /// <param name="ExpiredDateTime"></param>
        /// <returns></returns>
        public bool CheckDateTimeToken(DateTime ExpiredDateTime)
        {
            return true;
        }


    }
}
