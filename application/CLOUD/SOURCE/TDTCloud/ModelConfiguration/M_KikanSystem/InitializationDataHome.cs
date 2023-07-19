using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_KikanSystem
{
    public class InitializationDataHome
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token
        {
            get;
            set;
        }

        /// <summary>
        /// EventCode
        /// </summary>
        public string EventCode
        {
            get;
            set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public bool Status
        {
            get;
            set;
        }

        /// <summary>
        /// MessageErroe
        /// </summary>
        public string MessageErroe
        {
            get;
            set;
        }

        /// <summary>
        /// ListDataInitia
        /// </summary>
        public List<string> ListDataInitia { get; set; } = new List<string>();
    }
}
