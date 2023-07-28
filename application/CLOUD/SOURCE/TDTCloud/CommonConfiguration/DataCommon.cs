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
        public static string NotFindEmail = "Email Fail";

        /// <summary>
        /// IncorrectPassword
        /// </summary>
        public static string IncorrectPassword = "Password Fail";

        /// <summary>
        /// LockAccount
        /// </summary>
        public static string LockAccount = "Account Was Lock, Please Contact Manager";

        /// <summary>
        /// LoginFail
        /// </summary>
        public static string LoginFail = "SignIn Fail, Please Contact Manager";

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

        /// <summary>
        /// MessageNullToken
        /// </summary>
        public static string MessageNullToken = "Token Is Null, Please Contact Manager";

        /// <summary>
        /// MessageNullRoleNulUser
        /// </summary>
        public static string MessageNullRoleNulUser = "Role Is Null And User Is Null";

        /// <summary>
        /// MessageRoleUserLimit
        /// </summary>
        public static string MessageRoleUserLimit = "User Have Limit Role";

        /// <summary>
        /// MessageTokenWasExpire
        /// </summary>
        public static string MessageTokenWasExpire = "Token Was Expire, Please Contact Manager";

        /// <summary>
        /// MessageNotFindCityDistrict
        /// </summary>
        public static string MessageNotFindCityDistrict = "Not Find City Or District You Request, Please Contact Manager";

        /// <summary>
        /// MessageNotFindGender
        /// </summary>
        public static string MessageNotFindGender = "Not Find Gender You Request, Please Contact Manager";

        /// <summary>
        /// MessageNotFindMarriage
        /// </summary>
        public static string MessageNotFindMarriage = "Not Find Marriage You Request, Please Contact Manager";

        /// <summary>
        /// MessageEmailExist
        /// </summary>
        public static string MessageEmailExist = "Email You Requet Was Exist, Please Choose New Email";

        /// <summary>
        /// MessageRegiterFail
        /// </summary>
        public static string MessageRegiterFail = "Regiter Employee Fail, Please Contact Manager";

        /// <summary>
        /// MessageRegiterSuccess
        /// </summary>
        public static string MessageRegiterSuccess = "Regiter Success, User Can Use Account";

        /// <summary>
        /// MessageEmailOrPasswordIllegal
        /// </summary>
        public static string MessageEmailOrPasswordIllegal = "Email Or Password Illegal, Please Check Again";

        /// <summary>
        /// MessageMotFindTypeEmail
        /// </summary>
        public static string MessageNotFindTypeEmail = "Not Find Type Email In System, Please Contact Manager";

        /// <summary>
        /// MessageSignOutFail
        /// </summary>
        public static string MessageSignOutFail = "Not Find User Request SingOut, But System Still SignOut Infomation User. Please Contact Manager Support";

        /// <summary>
        /// MessageSingOutSuccess
        /// </summary>
        public static string MessageSingOutSuccess = "SingOut Success";

        /// <summary>
        /// MessageToken
        /// </summary>
        public static string MessageToken = "Token Is Still Valid";

        /// <summary>
        /// MessageBaseInfo
        /// </summary>
        public static string MessageBaseInfo = "Infomation Base Not Validation";

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
        /// EventSignOut
        /// </summary>
        public static string EventSignOut = "103";

        /// <summary>
        /// EventValidationToken
        /// </summary>
        public static string EventValidationToken = "104";

        /// <summary>
        /// EventInitialization
        /// </summary>
        public static string EventInitialization = "105";

        /// <summary>
        /// EventImportBooks
        /// </summary>
        public static string EventImportBooks = "106";

        /// <summary>
        /// EventImportAuthor
        /// </summary>
        public static string EventImportAuthor = "107";

        /// <summary>
        /// EventPublishingCompany
        /// </summary>
        public static string EventPublishingCompany = "108";

        /// <summary>
        /// EventCity
        /// </summary>
        public static string EventCity = "109";

        /// <summary>
        /// EventCategory
        /// </summary>
        public static string EventCategory = "110";

        /// <summary>
        /// EventError
        /// </summary>
        public static string EventError = "000";

        /// <summary>
        /// EventSuccess
        /// </summary>
        public static string EventSuccess = "001";

        ///--------------------------------------------Type Email-------------------------------------------------
        /// <summary>
        /// TypeRegiter
        /// </summary>
        public static int TypeRegiter = 01;


        ///--------------------------------------------Title sent Email-------------------------------------------------
        /// <summary>
        /// TitleEmailRegiter
        /// </summary>
        public static string TitleEmailRegiter = "TDT System Regiter Success";

    }
}
