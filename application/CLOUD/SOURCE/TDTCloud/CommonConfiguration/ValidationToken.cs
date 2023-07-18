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
        /// <summary>
        /// Contructor
        /// </summary>
        public ValidationToken()
        {
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
            // check RoleUser Limit by eventCode
            string roleUser = tokens.Claims.FirstOrDefault(claim => claim.Type == "roleID").Value;
            string userId = tokens.Claims.FirstOrDefault(claim => claim.Type == "userID").Value;
            string experiedToken = tokens.Claims.FirstOrDefault(claim => claim.Type == "experiedDate").Value;

            if(roleUser == null || userId == null || experiedToken == null)
            {
                result.Status = false;
                result.IdPlugin = DataCommon.EventError;
                result.Message = DataCommon.MessageNullRoleNulUser;
            }
            else
            {
                // Check ExpiredDateTime Token
                bool expiredToken = this.CheckDateTimeToken(DateTime.Parse(experiedToken));

                if (expiredToken)
                {
                    // Toke ExpiredDateTime
                    result.Status = false;
                    result.IdPlugin = DataCommon.EventError;
                    result.Message = DataCommon.MessageTokenWasExpire;
                }
                else
                {
                    // Token not ExpiredDateTime
                    result.Status = true;
                }
            }
            return result;
        }

        /// <summary>
        /// CheckDateTimeToken
        /// </summary>
        /// <param name="ExpiredDateTime"></param>
        /// <returns></returns>
        private bool CheckDateTimeToken(DateTime ExpiredDateTime)
        {
            bool result = false;
            
            if(ExpiredDateTime < DateTime.Now)
            {
                result = true;
            }
            return result;
        }


    }
}
