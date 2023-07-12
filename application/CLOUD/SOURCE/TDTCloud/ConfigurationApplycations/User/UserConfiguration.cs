using CodeFirtMigration.DataFE;
using CommonConfiguration.UserCommon;
using ConfigurationInterfaces.DataCommon;
using ConfigurationInterfaces.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelConfiguration.M_Common;
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
        private readonly IContactCommon contactCommon;

        /// <summary>
        /// Connection DBSet 
        /// </summary>
        /// <param name="_context"></param>
        public UserConfiguration(ContextFE _context, 
                                 UserManager<UserAccount> _userManager, 
                                 SignInManager<UserAccount> _signInManager,
                                 IConfiguration _configuration,
                                 IContactCommon _contactCommon)
        {
            this.context = _context;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.configuration = _configuration;
            this.contactCommon = _contactCommon;
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
                try
                {
                    // Check Email in DB
                    var checkEmail = await this.context.userAccounts.FirstOrDefaultAsync(x => x.Email == request.Email);
                    if (checkEmail == null)
                    {
                        result.Status = false;
                        result.Token = null;
                        result.Message = CommonConfiguration.DataCommon.NotFindEmail;
                    }
                    else
                    {
                        // Check Account have block
                        var checkLockAccount = await this.context.userAccounts.Where(x => x.Email == checkEmail.Email && x.IsActiver == true).ToArrayAsync();
                        if (checkLockAccount.Any() == true)
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
                            if (signAccount.Succeeded == false)
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
                                new Claim(ClaimTypes.Actor, queryRole.Description),
                                new Claim(ClaimTypes.DateOfBirth, DateTime.Now.AddMinutes(30).ToString())
                            };

                                // Create Token string
                                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Tokens:Issuer"]));
                                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                                var token = new JwtSecurityToken(this.configuration["Tokens:Issuer"],
                                    this.configuration["Tokens:Issuer"],
                                    claims,
                                    expires: DateTime.Now.AddMinutes(30),
                                    signingCredentials: creds
                                    );

                                result.Status = true;
                                result.Token = new JwtSecurityTokenHandler().WriteToken(token);
                                result.Message = CommonConfiguration.DataCommon.LoginSuccess;

                                // Save log login success
                                var logInfomation = new Log()
                                {
                                    Id = new Guid(),
                                    UserID = queryUser.UserID,
                                    Message = "Login System with role: " + queryRole.Description + " , login success",
                                    DateCreate = DateTime.Now,
                                    Status = true
                                };
                                await this.context.logs.AddAsync(logInfomation);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Status = false;
                    result.Message = ex.Message;
                    result.Token = null;

                    var checkEmail = await this.context.userAccounts.FirstOrDefaultAsync(x => x.Email == request.Email);
                    // Save log login success
                    var logInfomation = new Log()
                    {
                        Id = new Guid(),
                        UserID = checkEmail.UserID,
                        Message = "Error! An error occurred is: " + ex.Message,
                        DateCreate = DateTime.Now,
                        Status = true
                    };
                    await this.context.logs.AddAsync(logInfomation);
                }
            }
            await this.context.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// RegiterUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ReturnCommonApi> RegiterUser(RegiterUser request)
        {
            var result = new ReturnCommonApi();
            try
            {
                // Check Common 
                // Check City And District
                bool checkCityDistrict = this.contactCommon.ValidationCityDistrict(request.CityID, request.DistrictID);

                if (!checkCityDistrict)
                {
                    result.Status = false;
                    result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                    result.Message = CommonConfiguration.DataCommon.MessageNotFindCityDistrict;
                }
                else
                {
                    // Check Gender
                    var checkGender = this.contactCommon.ValidationGender(request.GenderID);

                    if (!checkGender)
                    {
                        result.Status = false;
                        result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                        result.Message = CommonConfiguration.DataCommon.MessageNotFindCityDistrict;
                    }
                    else
                    {
                        // Check Marriage
                        var checkMarriage = this.contactCommon.ValidationMarriage(request.MarriageID);

                        if (!checkMarriage)
                        {
                            result.Status = false;
                            result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                            result.Message = CommonConfiguration.DataCommon.MessageNotFindMarriage;
                        }
                        else
                        {
                            // Check Email And Password Illegal
                            var validationEmailPassword = ValidationLogin(request.Email, request.Password);
                            if (!validationEmailPassword)
                            {
                                result.Status = false;
                                result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                                result.Message = CommonConfiguration.DataCommon.MessageEmailOrPasswordIllegal;
                            }
                            else
                            {
                                // Check Email have Exist in DB 
                                var checkEmail = this.contactCommon.ValidationEmailEmployee(request.Email);

                                if (!checkEmail)
                                {
                                    result.Status = false;
                                    result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                                    result.Message = CommonConfiguration.DataCommon.MessageEmailExist;
                                }
                                else
                                {
                                    // Regiter User Into System
                                    int idUser = 0;
                                    var getUserMaxID = await this.context.users.OrderByDescending(x => x.UserID).FirstOrDefaultAsync();
                                    if (getUserMaxID != null)
                                    {
                                        idUser = Convert.ToInt32(getUserMaxID.UserID) + 1;
                                    }
                                    else
                                    {
                                        // ID Defaul
                                        idUser = 000001;
                                    }

                                    // Create Info Employee
                                    var regiterEmployee = new TDTSettingTable.User()
                                    {
                                        UserID = idUser.ToString(),
                                        FistName = request.FistName,
                                        LastName = request.LastName,
                                        Birthday = request.Birthday,
                                        GenderID = request.GenderID,
                                        MarriageID = request.MarriageID,
                                        DetailAddress = request.DetailAddress,
                                        Phone = request.Phone,
                                        Email = request.Email,
                                        DateCreate = DateTime.Now.ToString(),
                                        level = request.level,
                                        AddressCurent = request.AddressCurent,
                                        IsDeleteFlag = request.IsDeleteFlag,
                                        CityID = request.CityID,
                                        DistrictID = request.DistrictID,
                                    };

                                    // Create Account Employee
                                    var regiterAccount = new TDTSettingTable.UserAccount()
                                    {
                                        UserID = idUser.ToString(),
                                        DateCreate = DateTime.Now,
                                        RemmenberAccount = false,
                                        IsActiver = false,
                                        Id = new Guid(),
                                        UserName = request.Email,
                                        Email = request.Email,
                                        PhoneNumber = request.Phone,
                                        EmailConfirmed = true
                                    };

                                    // Insert Into DB
                                    var insertEmployee = await this.userManager.CreateAsync(regiterAccount, request.Password);

                                    if (!insertEmployee.Succeeded)
                                    {
                                        // Create Fail
                                        result.Status = false;
                                        result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                                        result.Message = CommonConfiguration.DataCommon.MessageRegiterFail;

                                        // Save Log
                                        var log = new Log()
                                        {
                                            Id = new Guid(),
                                            UserID = request.UserRegieter,
                                            Message = "Fail: Regiter Employee Fail Email Regiter: " + request.Email + " ,EventCode: " + request.EventCode,
                                            Status = false,
                                            DateCreate = DateTime.Now,
                                        };
                                        await this.context.logs.AddAsync(log);
                                    }
                                    else
                                    {
                                        // Create Success
                                        // Regiter Infomation Employee
                                        await this.context.users.AddAsync(regiterEmployee);
                                        result.Status = true;
                                        result.IdPlugin = CommonConfiguration.DataCommon.EventSuccess;
                                        result.Message = CommonConfiguration.DataCommon.MessageRegiterSuccess;

                                        // Save Log
                                        var log = new Log()
                                        {
                                            Id = new Guid(),
                                            UserID = request.UserRegieter,
                                            Message = "Success: Regiter Employee Success With: " + idUser.ToString() + " Email Regiter: " + request.Email + " ,EventCode: " + request.EventCode,
                                        };
                                        await this.context.logs.AddAsync(log);

                                        // Sent Email
                                        var sentMail = new CommonConfiguration.SentEmailCommon.SentEmail();
                                        bool resultSent = sentMail.SentEmailCommons(this.configuration["Smtp:UserName"],
                                                                                    this.configuration["Smtp:Password"],
                                                                                    request.Email,
                                                                                    CommonConfiguration.DataCommon.TypeRegiter,
                                                                                    CommonConfiguration.DataCommon.TitleEmailRegiter,
                                                                                    this.configuration["Smtp:Post"],
                                                                                    this.configuration["Smtp:Host"],
                                                                                    request.FistName + request.LastName);

                                        // If sent Email Fail break and not save Infomation User into DB
                                        if (!resultSent)
                                        {
                                            return result;
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Status = false;
                result.IdPlugin = CommonConfiguration.DataCommon.EventError;
                result.Message = ex.Message;

                // Save Log Exception
                var log = new Log()
                {
                    Id = new Guid(),
                    UserID = request.UserRegieter,
                    Message = "Exception is: " + ex.Message + " ,EventCode: " + request.EventCode,
                    DateCreate = DateTime.Now,
                };
                await this.context.logs.AddAsync(log);
            }
            await this.context.SaveChangesAsync();
            return  result;
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
