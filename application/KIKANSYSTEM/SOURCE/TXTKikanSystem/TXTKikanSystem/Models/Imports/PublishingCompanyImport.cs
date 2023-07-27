using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TXTKikanSystem.Models.Imports
{
    public class PublishingCompanyImport
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
        public DateTime DateOfIncorporation
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
        /// LasUpdateDate
        /// </summary>
        public DateTime? LasUpdateDate
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
