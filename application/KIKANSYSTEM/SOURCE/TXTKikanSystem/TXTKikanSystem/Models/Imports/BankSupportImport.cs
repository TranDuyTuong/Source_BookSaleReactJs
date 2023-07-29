using System;

namespace TXTKikanSystem.Models.Imports
{
    public class BankSupportImport
    {
        /// <summary>
        /// BankID
        /// </summary>
        public string BankID
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
        /// BankCode
        /// </summary>
        public string BankCode
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
        /// LasUpdateDate
        /// </summary>
        public DateTime? LasUpdateDate
        {
            get;
            set;
        }

        /// <summary>
        /// Content
        /// </summary>
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// UrlImageBank
        /// </summary>
        public string UrlImageBank
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
