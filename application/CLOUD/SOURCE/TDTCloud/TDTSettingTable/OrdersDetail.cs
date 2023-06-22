using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class OrdersDetail
    {
        /// <summary>
        /// OrderDetailID
        /// </summary>
        public Guid OrderDetailID
        {
            get;
            set;
        }

        /// <summary>
        /// OrderCode
        /// </summary>
        public string OrderCode
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
        /// Description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Quatity
        /// </summary>
        public int Quatity
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
        /// QuantityDiscountID
        /// </summary>
        public string QuantityDiscountID
        {
            get;
            set;
        }

        /// <summary>
        /// PairDiscountID
        /// </summary>
        public string PairDiscountID
        {
            get;
            set;
        }

        /// <summary>
        /// SpecialDiscountID
        /// </summary>
        public string SpecialDiscountID
        {
            get;
            set;
        }

        /// <summary>
        /// IssuingCompany
        /// </summary>
        public string IssuingCompany
        {
            get;
            set;
        }

        /// <summary>
        /// PublishingCompany
        /// </summary>
        public string PublishingCompany
        {
            get;
            set;
        }

        /// <summary>
        /// StatusPairDiscount
        /// </summary>
        public bool StatusPairDiscount
        {
            get;
            set;
        }

        /// <summary>
        /// StatusQuatityDiscount
        /// </summary>
        public bool StatusQuatityDiscount
        {
            get;
            set;
        }

    }
}
