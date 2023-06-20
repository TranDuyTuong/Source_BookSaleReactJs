using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class PublishingCompany
    {
        /// <summary>
        /// PublishingCompanyID
        /// </summary>
        public string PublishingCompanyID
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
        /// Address
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// DateCraete
        /// </summary>
        public DateTime DateCraete
        {
            get;
            set;
        }

        /// <summary>
        /// DateOfIncorporation
        /// </summary>
        public DateTime? DateOfIncorporation
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
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag
        {
            get;
            set;
        }
    }
}
