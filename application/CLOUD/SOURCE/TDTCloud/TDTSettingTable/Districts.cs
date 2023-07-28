using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class Districts
    {
        /// <summary>
        /// DistrictID
        /// </summary>
        public string DistrictID
        {
            get;
            set;
        }

        /// <summary>
        /// CityID
        /// </summary>
        public string CityID
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
        /// Description
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Identifier
        /// </summary>
        public string Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// DateCreate
        /// </summary>
        public string DateCreate
        {
            get;
            set;
        }

        /// <summary>
        /// PriceShip
        /// </summary>
        public decimal? PriceShip
        {
            get;
            set;
        }

        /// <summary>
        /// PriceShipNew
        /// </summary>
        public decimal? PriceShipNew
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
        /// HeadquartersLastUpdateDateTime
        /// </summary>
        public DateTime? HeadquartersLastUpdateDateTime
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
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag
        {
            get;
            set;
        }
    }
}
