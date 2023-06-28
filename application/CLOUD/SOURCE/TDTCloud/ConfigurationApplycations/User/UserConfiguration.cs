using CodeFirtMigration.DataFE;
using CommonConfiguration.UserCommon;
using ConfigurationInterfaces.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace ConfigurationApplycations.User
{
    public class UserConfiguration : IUserConfiguration
    {

        private readonly ContextFE context;
        private readonly UserManager<UserAccount> userManager;
        private readonly SignInManager<UserAccount> signInManager;

        /// <summary>
        /// Connection DBSet 
        /// </summary>
        /// <param name="_context"></param>
        public UserConfiguration(ContextFE _context, UserManager<UserAccount> _userManager, SignInManager<UserAccount> _signInManager)
        {
            this.context = _context;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
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
                result.Message = CommonConfiguration.DataCommon.IncorrectPassword;
            }
            else
            {
                // Check Email in DB
                var checkEmail = await this.userManager.FindByEmailAsync(request.Email);
                if(checkEmail == null)
                {
                    result.Status = false;
                    result.Token = null;
                    result.Message = CommonConfiguration.DataCommon.NotFindEmail;
                }
                else
                {
                    // Check Account have block
                    var checkLockAccount = await this.context.userAccounts.Where(x => x.Email == checkEmail.Email && x.IsActiver == true).ToArrayAsync();
                    if(checkLockAccount.Any() == true)
                    {
                        result.Status = false;
                        result.Token = null;
                        result.Message = CommonConfiguration.DataCommon.LockAccount;
                    }
                    else
                    {
                        // Check Password Login
                        var signAccount = await this.signInManager.PasswordSignInAsync(checkEmail, request.Password, true, true);
                        if(signAccount.Succeeded == false)
                        {
                            result.Status = false;
                            result.Token = null;
                            result.Message = CommonConfiguration.DataCommon.LoginFail;
                        }
                        else
                        {
                            // Login Success, create Token

                        }
                    }
                }
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
