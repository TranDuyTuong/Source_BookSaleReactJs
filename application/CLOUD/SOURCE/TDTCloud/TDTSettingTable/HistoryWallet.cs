using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class HistoryWallet
    {
        /// <summary>
        /// HistoryWalletID
        /// </summary>
        public Guid HistoryWalletID
        {
            get;
            set;
        }

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
        /// DateTimeCreate
        /// </summary>
        public DateTime DateTimeCreate
        {
            get;
            set;
        }

        /// <summary>
        /// PointsReceived
        /// </summary>
        public int PointsReceived
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
        /// IncreaseOrDecrease
        /// </summary>
        public bool IncreaseOrDecrease
        {
            get;
            set;
        }

        /// <summary>
        /// MethodsReceivingPoints
        /// </summary>
        public int? MethodsReceivingPoints
        {
            get;
            set;
        }
    }
}
