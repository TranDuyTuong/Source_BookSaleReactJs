using ModelConfiguration.M_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonConfiguration.UserCommon
{
    public class ValidationEventCode
    {
        /// <summary>
        /// CheckEventCode
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ReturnCommonApi CheckEventCode(string code)
        {
            var result = new ReturnCommonApi();
            // cutting strings
            string[] slipsCode = code.Split('_');
            switch (slipsCode[1])
            {
                // event regiter
                case var item when item == DataCommon.EventRegiter:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventRegiter,
                        Message = "Success EventCodeRegiter"
                    };
                    break;
                // event login
                case var item when item == DataCommon.EventLogin:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventLogin,
                        Message = "Success EventCodeLogin"
                    };
                    break;
                case var item when item == DataCommon.EventSignOut:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventSignOut,
                        Message = "Success EventCodeSignOut"
                    };
                    break;
                case var item when item == DataCommon.EventValidationToken:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventValidationToken,
                        Message = "Success EventValidationToken"
                    };
                    break;
                case var item when item == DataCommon.EventInitialization:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventInitialization,
                        Message = "Success EventInitialization"
                    };
                    break;
                case var item when item == DataCommon.EventImportBooks:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportBooks,
                        Message = "Success EventImportBooks"
                    };
                    break;
                case var item when item == DataCommon.EventImportAuthor:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportAuthor,
                        Message = "Success EventImportAuthor"
                    };
                    break;
                case var item when item == DataCommon.EventPublishingCompany:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventPublishingCompany,
                        Message = "Success EventPublishingCompany"
                    };
                    break;
                case var item when item == DataCommon.EventCity:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventCity,
                        Message = "Success EventCity"
                    };
                    break;
                default:
                    result = new ReturnCommonApi()
                    {
                        Status = false,
                        IdPlugin = DataCommon.EventError,
                        Message = "Error not find eventcode"
                    };
                    break;
            }
            return result;
        }

    }
}
