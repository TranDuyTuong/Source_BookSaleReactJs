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
            int maxLength = password.Length;
            if (maxLength > DataCommon.MaxLenghtPassword) {
                return false;
            }

            // Check Uppercase character password
            bool uppercasePassword = Char.IsUpper(Convert.ToChar(password));
            if (uppercasePassword == false)
            {
                return false;
            }

            // Check number in password
            bool checkNumber = Regex.IsMatch(password, @"\d");
            if (checkNumber == false)
            {
                return false;
            }

            // Check special characters in password
            bool checkSpecialCharacters = password.Any( x => !char.IsLetterOrDigit(x) );
            if (checkSpecialCharacters == false)
            {
                return false;
            }
            return true;
        }


    }
}
