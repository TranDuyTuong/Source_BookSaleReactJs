using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class CustomerAddressOrders
    {
        /// <summary>
        /// CustomerAddressOrdersID
        /// </summary>
        public Guid CustomerAddressOrdersID
        {
            get;
            set;
        }

        /// <summary>
        /// CustomerID
        /// </summary>
        public Guid CustomerID
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
        /// DetailAddress
        /// </summary>
        public string DetailAddress
        {
            get;
            set;
        }

        /// <summary>
        /// IsAddressHome
        /// </summary>
        public bool IsAddressHome
        {
            get;
            set;
        }

        /// <summary>
        /// IsAddressDefaul
        /// </summary>
        public bool IsAddressDefaul
        {
            get;
            set;
        }

        /// <summary>
        /// ShipPrice
        /// </summary>
        public decimal ShipPrice
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
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag
        {
            get;
            set;
        }
  }
}
