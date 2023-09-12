using ModelConfiguration.M_Bo.AuthorData;
using ModelConfiguration.M_Bo.CategoryData;
using ModelConfiguration.M_Bo.PublishingCompanysData;
using ModelConfiguration.M_Bo.StoreData;
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
        /// ValidationCityDistrict
        /// </summary>
        /// <param name="cityID"></param>
        /// <param name="districtID"></param>
        /// <returns></returns>
        bool ValidationCityDistrict(string cityID, string districtID);

        /// <summary>
        /// ValidationGender
        /// </summary>
        /// <param name="genderID"></param>
        /// <returns></returns>
        bool ValidationGender(string genderID);

        /// <summary>
        /// ValidationMarriage
        /// </summary>
        /// <param name="marriageID"></param>
        /// <returns></returns>
        bool ValidationMarriage(string marriageID);

        /// <summary>
        /// ValidationEmailEmployee
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ValidationEmailEmployee(string email);

        /// <summary>
        /// ValidationRoleUser
        /// </summary>
        /// <param name="role"></param>
        /// <param name="UserId"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        Task<bool> ValidationRoleUserLimit(string role, string UserId, string eventCode);

        /// <summary>
        /// ValidationCompanyCode
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        bool ValidationCompanyCode(string companyID);

        /// <summary>
        /// ValidationStoreCode
        /// </summary>
        /// <param name="storeID"></param>
        /// <returns></returns>
        bool ValidationStoreCode(string storeID);

        /// <summary>
        /// ValidationListStoreCode
        /// </summary>
        /// <param name="listStore"></param>
        /// <returns></returns>
        bool ValidationStoreCode(List<M_Store> listStore, string userID);

        /// <summary>
        /// ValidationAuthor
        /// </summary>
        /// <param name="listAuthor"></param>
        /// <returns></returns>
        bool ValidationAuthor(List<M_Author> listAuthor, string userID);

        /// <summary>
        /// ValidationCategory
        /// </summary>
        /// <param name="listCategory"></param>
        /// <returns></returns>
        bool ValidationCategory(List<M_Category> listCategory, string userID);

        /// <summary>
        /// ValidationPublishingCompany
        /// </summary>
        /// <param name="listPublishingCompany"></param>
        /// <returns></returns>
        bool ValidationPublishingCompany(List<M_PublishingCompany> listPublishingCompany, string userID);
    }
}
