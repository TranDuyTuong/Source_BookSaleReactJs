using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class CustomerReview
    {
        /// <summary>
        /// ReviewID
        /// </summary>
        public Guid ReviewID
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
        /// ItemCode
        /// </summary>
        public string ItemCode
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
        /// Description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// StartReview
        /// </summary>
        public int StartReview
        {
            get;
            set;
        }

        /// <summary>
        /// Like
        /// </summary>
        public int Like
        {
            get;
            set;
        }

        /// <summary>
        /// SatisfactionLevelID
        /// </summary>
        public string SatisfactionLevelID
        {
            get;
            set;
        }

        /// <summary>
        /// QuantityProductsPurchased
        /// </summary>
        public int QuantityProductsPurchased
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
