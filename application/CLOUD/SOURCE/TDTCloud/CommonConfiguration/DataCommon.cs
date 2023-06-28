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

    }
}
