using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TXTKikanSystem.Models.Imports
{
    public class MainImportSystem
    {
        /// <summary>
        /// listBooks
        /// </summary>
        public List<BooksImport> listBooks
        {
            get;
            set;
        } = new List<BooksImport>();

        /// <summary>
        /// FileName
        /// </summary>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// TypeImport
        /// </summary>
        public string TypeImport
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
        /// RoleID
        /// </summary>
        public string RoleID
        {
            get;
            set;
        }

        /// <summary>
        /// Token
        /// </summary>
        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// EventCode
        /// </summary>
        public string EventCode
        {
            get;
            set;
        }

        /// <summary>
        /// Company
        /// </summary>
        public string Company
        {
            get;
            set;
        }

        /// <summary>
        /// AreaCode
        /// </summary>
        public string AreaCode
        {
            get;
            set;
        }

        /// <summary>
        /// StoreCode
        /// </summary>
        public string StoreCode
        {
            get;
            set;
        }
    }
}
