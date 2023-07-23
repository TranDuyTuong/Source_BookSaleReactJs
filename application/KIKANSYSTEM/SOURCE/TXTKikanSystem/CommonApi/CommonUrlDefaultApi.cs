using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonApi
{
    public static class CommonUrlDefaultApi
    {
        /// <summary>
        /// UserLogin_Post
        /// </summary>
        public static string UserLogin_Post = "/User/Login";

        /// <summary>
        /// UserSignOut_Post
        /// </summary>
        public static string UserSignOut_Post = "/User/SignOut";

        /// <summary>
        /// TokenValidation_Post
        /// </summary>
        public static string TokenValidation_Post = "/User/ValidationTokenUser";

        /// <summary>
        /// InitializationHome_Post
        /// </summary>
        public static string InitializationHome_Post = "/KikanSystem/DataInitializationHome";

        /// <summary>
        /// GetTemplateImport_Post
        /// </summary>
        public static string ImportDataKikanSystem_Post = "/KikanSystem/GetTemplateImportBooks";

    }
}
