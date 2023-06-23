using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class SatisfactionLevel
    {
        /// <summary>
        /// SatisfactionLevelID
        /// </summary>
        public string SatisfactionLevelID
        {
            get;
            set;
        }

        /// <summary>
        /// ReviewID
        /// </summary>
        public Guid ReviewID
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
        /// FeelLever
        /// </summary>
        public int FeelLever
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

        /// <summary>
        /// StartReivew
        /// </summary>
        public bool StartReivew
        {
            get;
            set;
        }
    }
}
