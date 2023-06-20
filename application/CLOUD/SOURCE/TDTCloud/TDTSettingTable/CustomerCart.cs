using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class CustomerCart
    {
        /// <summary>
        /// CartID
        /// </summary>
        public Guid CartID
        {
            get;
            set;
        }

        /// <summary>
        /// ItemCode
        /// </summary>
        public string ItemCode
        {
            get;
            set;
        }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// DateAddPrtoduct
        /// </summary>
        public DateTime DateAddPrtoduct
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
        /// StatusProduct
        /// </summary>
        public bool StatusProduct
        {
            get;
            set;
        }

        /// <summary>
        /// PriceSale
        /// </summary>
        public decimal PriceSale
        {
            get;
            set;
        }

        /// <summary>
        /// PriceOrigin
        /// </summary>
        public decimal PriceOrigin
        {
            get;
            set;
        }

        /// <summary>
        /// PercentReduction
        /// </summary>
        public int PercentReduction
        {
            get;
            set;
        }

        /// <summary>
        /// TotalPrice
        /// </summary>
        public decimal TotalPrice
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
    }
}
