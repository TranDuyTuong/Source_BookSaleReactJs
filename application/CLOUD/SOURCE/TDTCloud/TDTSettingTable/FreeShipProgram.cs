using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class FreeShipProgram
    {
        /// <summary>
        /// CompanyCode
        /// </summary>
        public string CompanyCode
        {
            get;
            set;
        }

        /// <summary>
        /// FreeShipProgramID
        /// </summary>
        public string FreeShipProgramID
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
        /// ApplyDate
        /// </summary>
        public DateTime ApplyDate
        {
            get;
            set;
        }

        /// <summary>
        /// EndApplyDate
        /// </summary>
        public DateTime EndApplyDate
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
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag
        {
            get;
            set;
        }

    }
}
