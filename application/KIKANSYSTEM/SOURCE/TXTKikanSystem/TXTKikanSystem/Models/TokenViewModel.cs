using System;

namespace TXTKikanSystem.Models
{
    public class TokenViewModel
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
        /// Email
        /// </summary>
        public string Email 
        {
            get;
            set;
        }

        /// <summary>
        /// Role
        /// </summary>
        public string Role
        {
            get;
            set;
        }

        /// <summary>
        /// DescriptionRole
        /// </summary>
        public string DescriptionRole
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
        /// Employer
        /// </summary>
        public string Employer
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
        /// UserID
        /// </summary>
        public string UserID
        {
            get;
            set;
        }
    }
}
