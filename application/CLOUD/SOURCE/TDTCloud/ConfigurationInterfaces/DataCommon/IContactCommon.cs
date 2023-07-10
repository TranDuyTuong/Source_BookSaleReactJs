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
        /// ValidationRoleUser
        /// </summary>
        /// <param name="role"></param>
        /// <param name="UserId"></param>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        bool ValidationRoleUser(string role, string UserId, string eventCode);

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
    }
}
