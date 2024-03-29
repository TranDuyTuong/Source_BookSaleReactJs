﻿using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.DataCommon;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Bo.AuthorData;
using ModelConfiguration.M_Bo.CategoryData;
using ModelConfiguration.M_Bo.PublishingCompanysData;
using ModelConfiguration.M_Bo.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

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
        /// ValidationCityDistrict
        /// </summary>
        /// <param name="cityID"></param>
        /// <param name="districtID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationCityDistrict(string cityID, string districtID)
        {
            bool result = false;
            // Check city and district in DB
            var queryCity = from city in this.context.citys
                            where city.CityID == cityID
                            select city;

            var queryDistr = from district in this.context.districts
                             where district.DistrictID == districtID
                             select district;

            if (queryCity.Any() == true && queryDistr.Any() == true)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// ValidationCompanyCode
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationCompanyCode(string companyID)
        {
            bool result = false;
            // Check CompanyCode
            var queryCompanyCode = from c in this.context.areaMasters
                                   where c.CompanyCode == companyID
                                   select c;

            if (queryCompanyCode.Any() == true)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// ValidationEmailEmployee
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationEmailEmployee(string email)
        {
            bool result = false;
            // Check Email Employee request
            var queryEmail = from e in this.context.Users
                             where e.Email == email
                             select e;

            if (queryEmail.Any() == true)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// ValidationGender
        /// </summary>
        /// <param name="genderID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationGender(string genderID)
        {
            bool result = false;
            // Check Gender in DB
            var queryGender = from gender in this.context.genders
                              where gender.GenderID == genderID
                              select gender;

            if (queryGender.Any() == true)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// ValidationMarriage
        /// </summary>
        /// <param name="marriageID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationMarriage(string marriageID)
        {
            bool result = false;
            // Check Marriage in DB
            var queryMarriage = from marriage in this.context.marriages
                                where marriage.MarriageID == marriageID
                                select marriage;

            if(queryMarriage.Any() == true)
            {
                result |= true;
            }
            return result;
        }

        /// <summary>
        /// ValidationRoleUserLimit
        /// </summary>
        /// <param name="role"></param>
        /// <param name="UserId"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> ValidationRoleUserLimit(string role, string UserId, string eventCode)
        {
            // check role
            var getRole = this.context.Roles.Where(x => x.RoleID == role).ToArray();

            if (getRole.Length <= 0)
            {
                return false;
            }

            var getUser = await this.context.userAccounts.FirstOrDefaultAsync(x => x.UserID == UserId);

            if (getUser == null)
            {
                return false;
            }

            // check user role
            var checkUserRole = this.context.userRoles.Where(x => x.RoleID == role &&
                                                                x.UserID == UserId &&
                                                                    x.EventCodeLimit == eventCode).ToArray();

            if (checkUserRole.Any())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ValidationStoreCode
        /// </summary>
        /// <param name="storeID">storeID</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationStoreCode(string storeID)
        {
            // check storeCode
            var queryStore = this.context.stores.Where(x => x.StoreCode == storeID && x.IsDeleteFlag == false).ToArray();

            if(queryStore.Any() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ValidationStoreCode
        /// </summary>
        /// <param name="listStore"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationStoreCode(List<M_Store> listStore, string userID)
        {
            // Get All Store In DB
            var queryStore = this.context.stores.Where(x => x.IsDeleteFlag == false).ToArray();

            foreach(var store in listStore)
            {
                var item = queryStore.FirstOrDefault(x => x.StoreCode == store.StoreCode);
                
                if(item == null)
                {
                    // Save Log Error
                    var logError = new Log()
                    {
                        Id = new Guid(),
                        UserID = userID,
                        Message = "Error! Not Find Store Code: " + store.StoreCode,
                        DateCreate = DateTime.Now,
                        Status = true
                    };
                    this.context.logs.Add(logError);
                    this.context.SaveChanges();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ValidationAuthor
        /// </summary>
        /// <param name="listAuthor"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationAuthor(List<M_Author> listAuthor, string userID)
        {
            // Get All Author In DB
            var queryAuthor = this.context.authors.Where(x => x.IsDeleteFlag == false).ToArray();

            foreach(var author in listAuthor)
            {
                var item = queryAuthor.FirstOrDefault(x => x.AuthorID == author.AuthorID);

                if(item == null)
                {
                    // Save Log Error
                    var logError = new Log()
                    {
                        Id = new Guid(),
                        UserID = userID,
                        Message = "Error! Not Find Author Code: " + author.AuthorID,
                        DateCreate = DateTime.Now,
                        Status = true
                    };
                    this.context.logs.Add(logError);
                    this.context.SaveChanges();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ValidationCategory
        /// </summary>
        /// <param name="listCategory"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationCategory(List<M_Category> listCategory, string userID)
        {
            // Get All Category In DB
            var queryCategory = this.context.categoryItemMasters.Where(x => x.IsDeleteFlag == false).ToArray();

            foreach(var category in listCategory)
            {
                var item = queryCategory.FirstOrDefault(x => x.CategoryItemMasterID ==  category.CategoryItemMasterID);

                if(item == null)
                {
                    // Save Log Error
                    var logError = new Log()
                    {
                        Id = new Guid(),
                        UserID = userID,
                        Message = "Error! Not Find Category: " + category.CategoryItemMasterID,
                        DateCreate = DateTime.Now,
                        Status = true
                    };
                    this.context.logs.Add(logError);
                    this.context.SaveChanges();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ValidationPublishingCompany
        /// </summary>
        /// <param name="listPublishingCompany"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool ValidationPublishingCompany(List<M_PublishingCompany> listPublishingCompany, string userID)
        {
            return true;
        }


    }
}
