using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class ImageReview
    {
        /// <summary>
        /// ImageID
        /// </summary>
        public Guid ImageID
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
        /// ImageName
        /// </summary>
        public string ImageName
        {
            get;
            set;
        }

        /// <summary>
        /// TypeImage
        /// </summary>
        public string TypeImage
        {
            get;
            set;
        }

        /// <summary>
        /// Url
        /// </summary>
        public string Url
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
        /// IsDeleteFlag
        /// </summary>
        public bool IsDeleteFlag
        {
            get;
            set;
        }
    }
}
