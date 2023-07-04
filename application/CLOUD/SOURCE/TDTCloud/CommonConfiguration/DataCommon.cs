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

        /// <summary>
        /// LoginSuccess
        /// </summary>
        public static string LoginSuccess = "000_5";

        /// <summary>
        /// MessageErrorEvent
        /// </summary>
        public static string MessageErrorEvent = "Not Find Event Request, Please Contact Manager";

        /// <summary>
        /// MessageNullData
        /// </summary>
        public static string MessageNullData = "Value Is Null, Please Contact Manager";


        ///-------------------------------------------Event Code-------------------------------------------------
        /// <summary>
        /// EventRegiter
        /// </summary>
        public static string EventRegiter = "101";

        /// <summary>
        /// EventLogin
        /// </summary>
        public static string EventLogin = "102";

        /// <summary>
        /// EventError
        /// </summary>
        public static string EventError = "000";


    }
}
