using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelConfiguration.M_Users
{
    public class IdentityUserLogin
    {
        //
        // Summary:
        //     Gets or sets the primary key of the user associated with this login.
        public Guid UserId { get; set; }

        //
        // Summary:
        //     Gets or sets the login provider for the login (e.g. facebook, google)
        public string LoginProvider { get; set; }

        //
        // Summary:
        //     Gets or sets the unique provider identifier for this login.
        public string ProviderKey { get; set; }

        //
        // Summary:
        //     Gets or sets the friendly name used in a UI for this login.
        public string ProviderDisplayName { get; set; }

    }
}
