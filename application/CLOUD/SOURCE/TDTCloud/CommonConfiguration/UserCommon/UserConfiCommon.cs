using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonConfiguration.UserCommon
{
    public class UserConfiCommon
    {
        /// <summary>
        /// CheckMaxLengthPassword
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckMaxLengthPassword(string password)
        {
            // Check MaxLength
            int passwordLength = password.Length;
            if (passwordLength > DataCommon.MaxLenghtPassword) {
                return false;
            }

            // Check MinLength
            if(passwordLength < DataCommon.MinLenghtPassword)
            {
                return false;
            }

            // Regex string check password
            Regex stringRegexValidation = DataCommon.StringRegex;
            if(stringRegexValidation.IsMatch(password) == false)
            {
                return false;
            }
            return true;
        }


    }
}
