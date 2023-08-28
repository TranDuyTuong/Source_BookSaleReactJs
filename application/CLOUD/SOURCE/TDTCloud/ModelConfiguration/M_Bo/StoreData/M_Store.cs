using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_Bo.StoreData
{
    public class M_Store
    {
        /// <summary>
        /// StoreCode
        /// </summary>
        public string StoreCode
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
        /// LastUpdateDate
        /// </summary>
        public string LastUpdateDate
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
        /// TypeOf
        /// </summary>
        public string TypeOf
        {
            get;
            set;
        }

        /// <summary>
        /// OldType
        /// </summary>
        public string OldType
        {
            get;
            set;
        }
    }
}
