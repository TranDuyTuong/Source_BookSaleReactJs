using ModelConfiguration.M_Bo.AreaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_Bo.ItemMasterData
{
    public class M_ListItemMaster
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
        /// TotalItemMaster
        /// </summary>
        public int TotalItemMaster
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
        /// OTPControl (0 => create, 1 => update base, 2 => delete)
        /// </summary>
        public int OTPControl
        {
            get;
            set;
        }

        /// <summary>
        /// ListItemMaster
        /// </summary>
        public List<M_ItemMaster> ListItemMaster
        {
            get;
            set;
        } = new List<M_ItemMaster>();
    }
}
