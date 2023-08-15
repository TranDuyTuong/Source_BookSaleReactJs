using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_Bo.AreaData
{
    public class M_ListArea
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
        /// UserID
        /// </summary>
        public string UserID
        {
            get;
            set;
        }

        /// <summary>
        /// RoleID
        /// </summary>
        public string RoleID
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
        /// TotalArea
        /// </summary>
        public int TotalArea
        {
            get;
            set;
        }

        /// <summary>
        /// MessageError
        /// </summary>
        public string MessageError
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
        /// KeySeach
        /// </summary>
        public string KeySeach
        {
            get;
            set;
        }

        /// <summary>
        /// CompanyCode
        /// </summary>
        public string CompanyCode
        {
            get;
            set;
        }

        /// <summary>
        /// ListArea
        /// </summary>
        public List<M_Area> ListArea 
        {
            get;
            set;
        } = new List<M_Area>();
    }
}
