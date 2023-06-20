using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class Author
    {
        /// <summary>
        /// AuthorID
        /// </summary>
        public string AuthorID
        {
            get;
            set;
        }

        /// <summary>
        /// NameAuthor
        /// </summary>
        public string NameAuthor
        {
            get;
            set;
        }

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? Birthday
        {
            get;
            set;
        }

        /// <summary>
        /// Hometown
        /// </summary>
        public string Hometown
        {
            get;
            set;
        }

        /// <summary>
        /// Discription
        /// </summary>
        public string Discription
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
        /// HeadquartersLastUpdateDateTime
        /// </summary>
        public DateTime? HeadquartersLastUpdateDateTime
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
        /// TotalBook
        /// </summary>
        public int TotalBook
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
