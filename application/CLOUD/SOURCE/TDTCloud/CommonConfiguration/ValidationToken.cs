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
            context = _context;
        }

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
            string roleUser = tokens.Claims.FirstOrDefault(claim => claim.Type == "Role").Value;
            string userId = tokens.Claims.FirstOrDefault(claim => claim.Type == "Email").Value;
            string experiedToken = tokens.Claims.FirstOrDefault(claim => claim.Type == "DateOfBirth").Value;

            if(roleUser == null || userId == null || experiedToken == null)
            {
                result.Status = false;
                result.IdPlugin = DataCommon.EventError;
                result.Message = DataCommon.MessageNullRoleNulUser;
            }
            else
            {
                bool checkRoleUser = CheckRoleUser(roleUser, userId, eventcode);

                if(checkRoleUser == true) 
                {
                    // Have Role User Limit 
                    result.Status = false;
                    result.IdPlugin = DataCommon.EventError;
                    result.Message = DataCommon.MessageRoleUserLimit;
                }
                else
                {
                    // Check Time Expired
                    DateTime dateTimeExperied = DateTime.Parse(experiedToken);
                    bool checkExperiedToken = CheckDateTimeToken(dateTimeExperied);
                    if(checkExperiedToken == true)
                    {
                        // Token was expire
                        result.Status = false;
                        result.IdPlugin = DataCommon.EventError;
                        result.Message = DataCommon.MessageTokenWasExpire;
                    }
                    else
                    {
                        result.Status = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// CheckRoleUser
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private bool CheckRoleUser(string roleId, string userId, string eventCode)
        {
            var result = this.context.ValidationRoleUser(roleId, userId, eventCode);

            if(result == true)
            {
                // Find UserRole limit
                return true;
            }
            else
            {
                // Not Find UserRole limit
                return false;
            }
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
