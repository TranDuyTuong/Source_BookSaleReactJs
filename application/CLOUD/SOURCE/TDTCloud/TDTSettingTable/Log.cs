using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class Log
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { 
            get; 
            set; 
        }

        /// <summary>
        /// UserID
        /// </summary>
        public string UserID { 
            get;
            set;
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { 
            get; 
            set; 
        }

        /// <summary>
        /// DateCreate
        /// </summary>
        public DateTime DateCreate { 
            get; 
            set; 
        }

        /// <summary>
        /// Status
        /// </summary>
        public bool Status { 
            get; 
            set; 
        }
    }
}
