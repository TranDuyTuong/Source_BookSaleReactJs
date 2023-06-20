using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class PairDiscount
    {
        /// <summary>
        /// PairDiscountID
        /// </summary>
        public string PairDiscountID
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
        /// ApplyDate
        /// </summary>
        public DateTime ApplyDate
        {
            get;
            set;
        }

        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime EndDate
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
        /// DateCreate
        /// </summary>
        public DateTime DateCreate
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
        /// LastUpdateDate
        /// </summary>
        public DateTime? LastUpdateDate
        {
            get;
            set;
        }

        /// <summary>
        /// ContentLastUpdateDate
        /// </summary>
        public string ContentLastUpdateDate
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

        /// <summary>
        /// Expired
        /// </summary>
        public bool Expired
        {
            get;
            set;
        }
    }
}
