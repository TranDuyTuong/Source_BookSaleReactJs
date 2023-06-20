using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class Productsviewedbycustomers
    {
        /// <summary>
        /// ViewerID
        /// </summary>
        public int ViewerID
        {
            get;
            set;
        }

        /// <summary>
        /// CustomerID
        /// </summary>
        public Guid CustomerID
        {
            get;
            set;
        }

        /// <summary>
        /// ItemCode
        /// </summary>
        public string ItemCode
        {
            get;
            set;
        }

        /// <summary>
        /// DateViewer
        /// </summary>
        public DateTime DateViewer
        {
            get;
            set;
        }

        /// <summary>
        /// ViewerNumber
        /// </summary>
        public int ViewerNumber
        {
            get;
            set;
        }
    }
}
