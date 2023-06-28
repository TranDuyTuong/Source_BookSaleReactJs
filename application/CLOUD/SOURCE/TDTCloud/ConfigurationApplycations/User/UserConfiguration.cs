using CodeFirtMigration.DataFE;
using CommonConfiguration.UserCommon;
using ConfigurationInterfaces.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelConfiguration.M_Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        private readonly IConfiguration configuration;

        /// <summary>
        /// Connection DBSet 
        /// </summary>
        /// <param name="_context"></param>
        public UserConfiguration(ContextFE _context, 
                                 UserManager<UserAccount> _userManager, 
                                 SignInManager<UserAccount> _signInManager,
                                 IConfiguration _configuration)
        {
            this.context = _context;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.configuration = _configuration;
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
                var checkEmail = await this.context.userAccounts.FirstOrDefaultAsync(x => x.Email == request.Email);
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

                        // Save log fail account lock
                        var logInfomation = new Log()
                        {
                            Id = new Guid(),
                            UserID = checkEmail.UserID,
                            Message = "Login System fail, account was lock",
                            DateCreate = DateTime.Now,
                            Status = true
                        };
                        await this.context.logs.AddAsync(logInfomation);
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

                            // Save log fail password
                            var logInfomation = new Log()
                            {
                                Id = new Guid(),
                                UserID = checkEmail.UserID,
                                Message = "Login System fail, password not incorrect",
                                DateCreate = DateTime.Now,
                                Status = true
                            };
                            await this.context.logs.AddAsync(logInfomation);
                        }
                        else
                        {
                            // Login Success, create Token
                            var queryUser = await this.context.users.SingleAsync(x => x.Email == checkEmail.Email);
                            var queryUserRole = await this.context.userRoles.Where(x => x.UserID == queryUser.UserID).ToArrayAsync();
                            var queryRole = await this.context.roles.FirstOrDefaultAsync(x => x.RoleID == queryUserRole.FirstOrDefault().RoleID);

                            // Create claims infomation
                            var claims = new[]
                            {
                                new Claim(ClaimTypes.Email, queryUser.Email),
                                new Claim(ClaimTypes.Name, queryUser.FistName + "" + queryUser.LastName),
                                new Claim(ClaimTypes.Role, queryRole.RoleID),
                                new Claim(ClaimTypes.Actor, queryRole.Name),
                                new Claim(ClaimTypes.DateOfBirth, DateTime.Now.ToString())
                            };

                            // Create Token string
                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Tokens:Issuer"]));
                            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                            var token = new JwtSecurityToken(this.configuration["Tokens:Issuer"],
                                this.configuration["Tokens:Issuer"],
                                claims,
                                expires: DateTime.Now.AddMinutes(30),
                                signingCredentials:creds
                                );

                            result.Status = true;
                            result.Token = new JwtSecurityTokenHandler().WriteToken(token);
                            result.Message = CommonConfiguration.DataCommon.LoginSuccess;

                            // Save log login success
                            var logInfomation = new Log()
                            {
                                Id = new Guid(),
                                UserID = queryUser.UserID,
                                Message = "Login System with role: " + queryRole.Name + " , login success",
                                DateCreate = DateTime.Now,
                                Status = true
                            };
                            await this.context.logs.AddAsync(logInfomation);
                        }
                    }
                }
            }
            await this.context.SaveChangesAsync();
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
