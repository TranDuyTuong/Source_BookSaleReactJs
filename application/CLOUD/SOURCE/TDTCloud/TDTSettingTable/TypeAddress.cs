using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class TypeAddress
    {
        /// <summary>
        /// TypeAddressID
        /// </summary>
        public string TypeAddressID
        {
            get;
            set;
        }

        /// <summary>
        /// Discription
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// DateTimeCreate
        /// </summary>
        public DateTime DateTimeCreate
        {
            get;
            set;
        }

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        public DateTime? LastUpdateDate
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
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag
        {
            get;
            set;
        }

    }
}
