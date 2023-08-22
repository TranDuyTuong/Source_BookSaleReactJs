﻿using ModelConfiguration.M_Bo.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.BoSystem
{
    public interface IStoreBO
    {
        /// <summary>
        /// SeachStore
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <param name="token"></param>
        /// <param name="eventCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        Task<M_ListStore> SeachStore(string request, string userID, string roleID, string token, string eventCode, string companyCode);

        /// <summary>
        /// DetailStore
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <param name="token"></param>
        /// <param name="eventCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        Task<M_ListStore> DetailStore(string request, string userID, string roleID, string token, string eventCode, string companyCode);

        /// <summary>
        /// ConfirmStore
        /// </summary>
        /// <param name="request">request</param>
        /// <returns></returns>
        Task<M_ListStore> ConfirmStore(M_ListStore request);
    }
}
