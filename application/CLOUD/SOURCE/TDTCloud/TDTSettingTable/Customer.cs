using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class Customer
    {
        /// <summary>
        /// CustomerID
        /// </summary>
        public Guid CustomerID
        {
            get;
            set;
        }

        /// <summary>
        /// FullName
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime Birthday
        {
            get;
            set;
        }

        /// <summary>
        /// Email
        /// </summary>
        public Guid Email
        {
            get;
            set;
        }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get;
            set;
        }

        /// <summary>
        /// CityID
        /// </summary>
        public string CityID
        {
            get;
            set;
        }

        /// <summary>
        /// DistrictID
        /// </summary>
        public string DistrictID
        {
            get;
            set;
        }

        /// <summary>
        /// GenderID
        /// </summary>
        public string GenderID
        {
            get;
            set;
        }

        /// <summary>
        /// MarriageID
        /// </summary>
        public string MarriageID
        {
            get;
            set;
        }

        /// <summary>
        /// DateRegiter
        /// </summary>
        public DateTime DateRegiter
        {
            get;
            set;
        }

        /// <summary>
        /// Vip
        /// </summary>
        public bool Vip
        {
            get;
            set;
        }

        /// <summary>
        /// StatusAccount
        /// </summary>
        public bool StatusAccount
        {
            get;
            set;
        }

        /// <summary>
        /// JobID
        /// </summary>
        public string JobID
        {
            get;
            set;
        }

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        public DateTime LastUpdateDate
        {
            get;
            set;
        }

        /// <summary>
        /// DetailAddress
        /// </summary>
        public bool DetailAddress
        {
            get;
            set;
        }

        /// <summary>
        /// DiscriptionLastUpdateDate
        /// </summary>
        public string DiscriptionLastUpdateDate
        {
            get;
            set;
        }
    }
}
