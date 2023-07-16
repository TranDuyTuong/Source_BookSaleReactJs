using System;

namespace TXTKikanSystem.Models
{
    public class SignOutUser
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
        /// ExpirationDate
        /// </summary>
        public DateTime ExpirationDate
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

    }
}
