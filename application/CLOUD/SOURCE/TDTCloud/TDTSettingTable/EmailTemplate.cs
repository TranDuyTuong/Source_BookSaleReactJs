using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class EmailTemplate
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// TypeCode
        /// </summary>
        public string TypeCode
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
        /// DateCreate
        /// </summary>
        public DateTime DateCreate
        {
            get;
            set;
        }

        /// <summary>
        /// IsActiver
        /// </summary>
        public bool IsActiver
        {
            get;
            set;
        }

        /// <summary>
        /// TitleBody
        /// </summary>
        public string TitleBody
        {
            get;
            set;
        }

        /// <summary>
        /// ContentBody
        /// </summary>
        public string ContentBody
        {
            get;
            set;
        }

        /// <summary>
        /// Goodbye
        /// </summary>
        public string Goodbye
        {
            get;
            set;
        }

        /// <summary>
        /// TemSystem
        /// </summary>
        public string TemSystem
        {
            get;
            set;
        }

        /// <summary>
        /// PhoneContact
        /// </summary>
        public string PhoneContact
        {
            get;
            set;
        }

        /// <summary>
        /// LastUpdateDate
        /// </summary>
        public string LastUpdateDate
        {
            get;
            set;
        }
    }
}
