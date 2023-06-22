using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class CustomerWallet
    {
        /// <summary>
        /// WalletID
        /// </summary>
        public string WalletID
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
        /// FirstDateTime
        /// </summary>
        public DateTime FirstDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// PointCurent
        /// </summary>
        public int PointCurent
        {
            get;
            set;
        }

        /// <summary>
        /// PointMax
        /// </summary>
        public int PointMax
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
        /// PointPlusLastUpdate
        /// </summary>
        public int PointPlusLastUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// SatusPointLastUpdate
        /// </summary>
        public bool SatusPointLastUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// PointMinusLastUpdate
        /// </summary>
        public int PointMinusLastUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// StatusWallet
        /// </summary>
        public bool StatusWallet
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
        /// BlockDateTime
        /// </summary>
        public DateTime? BlockDateTime
        {
            get;
            set;
        }
    }
}
