using CodeFirtMigration.DataFE;
using CommonConfiguration.UserCommon;
using ConfigurationInterfaces.User;
using ModelConfiguration.M_Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationApplycations.User
{
    public class UserConfiguration : IUserConfiguration
    {

        private readonly ContextFE context;

        /// <summary>
        /// Connection DBSet 
        /// </summary>
        /// <param name="_context"></param>
        public UserConfiguration(ContextFE _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// AuthorzirationUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ReturnLoginApi> AuthorzirationUser(LoginUser request)
        {
            var result = new ReturnLoginApi();
            // Check validation Email, Password 
            var checkResult = ValidationLogin(request.Email, request.Password);
            if(checkResult == false)
            {
                result.Status = false;
                result.Token = null;
                result.Message = "Login Fail";
            }
            else
            {

            }
            return result;
        }

        /// <summary>
        /// Validation Account login
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        private bool ValidationLogin(string Email, string Password)
        {
            // Check Null Email and Password
            if(Email == null || Password == null)
            {
                return false;
            }
            else
            {
                // Check Email
                var trimmedEmail = Email.Trim();

                if (trimmedEmail.EndsWith("."))
                {
                    return false; // suggested by @TK-421
                }
                try
                {
                    var addr = new System.Net.Mail.MailAddress(Email);
                    if (addr.Address == trimmedEmail)
                    {
                        // Check Characters password
                        bool passwordCheck = UserConfiCommon.CheckMaxLengthPassword(Password);
                        if (passwordCheck == false) 
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

        }



    }
}
