using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_ImportData
{
    public class ImportCitys
    {
        /// <summary>
        /// CityID
        /// </summary>
        public string CityID { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// AreaCode
        /// </summary>
        public int AreaCode { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// HeadquartersLastUpdateDateTime
        /// </summary>
        public DateTime? HeadquartersLastUpdateDateTime { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag { get; set; }
    }
}
