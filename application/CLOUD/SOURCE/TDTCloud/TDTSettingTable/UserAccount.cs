using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDTSettingTable
{
    public class UserAccount: IdentityUser<Guid>
    {
        /// <summary>
        /// UserID
        /// </summary>
        public string UserID
        {
            get;
            set;
        }

        /// <summary>
        /// Password
        /// </summary>
        public string Password
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
        /// DateCreate
        /// </summary>
        public DateTime DateCreate
        {
            get;
            set;
        }

        /// <summary>
        /// RemmenberAccount
        /// </summary>
        public bool RemmenberAccount
        {
            get;
            set;
        }

        /// <summary>
        /// IsActiver
        /// </summary>
        public bool IsActiver
        {
            get;
            set;
        }
    }
}
