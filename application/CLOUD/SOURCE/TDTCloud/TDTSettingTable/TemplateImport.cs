using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class TemplateImport
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
        /// TypeId
        /// </summary>
        public string TypeId
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
        /// Content
        /// </summary>
        public string Content
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
        /// LastUpdateDate
        /// </summary>
        public DateTime? LastUpdateDate
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
        /// IsDelete
        /// </summary>
        public bool IsDelete
        {
            get;
            set;
        }
    }
}
