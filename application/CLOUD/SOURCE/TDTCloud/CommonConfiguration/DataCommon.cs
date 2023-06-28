using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonConfiguration
{
    public class DataCommon
    {
        /// <summary>
        /// MaxLenghtPassword
        /// </summary>
        public static int MaxLenghtPassword = 10;

        /// <summary>
        /// MinLenghtPassword
        /// </summary>
        public static int MinLenghtPassword = 8;

        /// <summary>
        /// StringRegex
        /// </summary>
        public static Regex StringRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

        /// <summary>
        /// NotFindEmail
        /// </summary>
        public static string NotFindEmail = "000_1";

        /// <summary>
        /// IncorrectPassword
        /// </summary>
        public static string IncorrectPassword = "000_2";

        /// <summary>
        /// LockAccount
        /// </summary>
        public static string LockAccount = "000_3";

        /// <summary>
        /// LoginFail
        /// </summary>
        public static string LoginFail = "000_4";


    }
}
