using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_Users
{
    public class LoginUser
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { 
            get; 
            set; 
        }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { 
            get; 
            set; 
        }

        /// <summary>
        /// RememberMe
        /// </summary>
        public bool RememberMe { 
            get; 
            set; 
        }

        /// <summary>
        /// EventCode
        /// </summary>
        public string EventCode { 
            get; 
            set; 
        }
    }
}
