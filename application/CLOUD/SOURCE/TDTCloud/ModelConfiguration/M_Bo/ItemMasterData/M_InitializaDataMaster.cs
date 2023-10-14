using ModelConfiguration.M_Bo.AuthorData;
using ModelConfiguration.M_Bo.CategoryData;
using ModelConfiguration.M_Bo.PublishingCompanysData;
using ModelConfiguration.M_Bo.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_Bo.ItemMasterData
{
    public class M_InitializaDataMaster
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// UserID
        /// </summary>
        public string UserID
        {
            get;
            set;
        }

        /// <summary>
        /// RoleID
        /// </summary>
        public string RoleID
        {
            get;
            set;
        }

        /// <summary>
        /// EventCode
        /// </summary>
        public string EventCode
        {
            get;
            set;
        }

        /// <summary>
        /// MessageError
        /// </summary>
        public string MessageError
        {
            get;
            set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public bool Status
        {
            get;
            set;
        }

        /// <summary>
        /// KeySeach
        /// </summary>
        public string KeySeach
        {
            get;
            set;
        }

        /// <summary>
        /// CompanyCode
        /// </summary>
        public string CompanyCode
        {
            get;
            set;
        }

        /// <summary>
        /// StoreCode
        /// </summary>
        public string StoreCode
        {
            get;
            set;
        }

        /// <summary>
        /// ListStore
        /// </summary>
        public List<M_Store> ListStore
        {
            get;
            set;
        } = new List<M_Store>();

        /// <summary>
        /// ListAuthor
        /// </summary>
        public List<M_Author> ListAuthor
        {
            get;
            set;
        } = new List<M_Author>();

        /// <summary>
        /// ListCategory
        /// </summary>
        public List<M_Category> ListCategory
        {
            get;
            set;
        } = new List<M_Category>();
    }
}
