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
                // event singout
                case var item when item == DataCommon.EventSignOut:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventSignOut,
                        Message = "Success EventCodeSignOut"
                    };
                    break;
                // event validation token
                case var item when item == DataCommon.EventValidationToken:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventValidationToken,
                        Message = "Success EventValidationToken"
                    };
                    break;
                // event Initialization
                case var item when item == DataCommon.EventInitialization:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventInitialization,
                        Message = "Success EventInitialization"
                    };
                    break;
                // event ImportBooks
                case var item when item == DataCommon.EventImportBooks:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportBooks,
                        Message = "Success EventImportBooks"
                    };
                    break;
                // event ImportAuthor
                case var item when item == DataCommon.EventImportAuthor:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportAuthor,
                        Message = "Success EventImportAuthor"
                    };
                    break;
                // event ImportPublishingCompany
                case var item when item == DataCommon.EventImportPublishingCompany:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportPublishingCompany,
                        Message = "Success EventPublishingCompany"
                    };
                    break;
                // event ImportCity
                case var item when item == DataCommon.EventImportCity:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportCity,
                        Message = "Success EventCity"
                    };
                    break;
                // event ImportCategory
                case var item when item == DataCommon.EventImportCategory:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportCategory,
                        Message = "Success EventCategory"
                    };
                    break;
                // event ImportDistrict
                case var item when item == DataCommon.EventImportDistrict:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportDistrict,
                        Message = "Success EventDistrict"
                    };
                    break;
                // event ImportBankSupport
                case var item when item == DataCommon.EventImportBankSupport:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportBankSupport,
                        Message = "Success EventBankSupport"
                    };
                    break;
                // event ImportIssuingCompanys
                case var item when item == DataCommon.EventImportIssuingCompanys:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventImportIssuingCompanys,
                        Message = "Success EventIssuingCompanys"
                    };
                    break;
                // event Go To Home Bo
                case var item when item == DataCommon.EventBO_Home:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventBO_Home,
                        Message = "Success Event Bo Home"
                    };
                    break;
                // event Handle Seach Area
                case var item when item == DataCommon.EventBO_SeachArea:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventBO_SeachArea,
                        Message = "Success Event Bo Seach Area"
                    };
                    break;
                // event Handle Confirm Area
                case var item when item == DataCommon.EventBo_ConfirmArea:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventBo_ConfirmArea,
                        Message = "Success Event Bo Confirm Area"
                    };
                    break;
                // event Handle Seach Store
                case var item when item == DataCommon.EventBo_SeachStore:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventBo_ConfirmArea,
                        Message = "Success Event Bo Seach Store"
                    };
                    break;
                // event Handle Confirm Store
                case var item when item == DataCommon.EventBo_ConfirmStore:
                    result = new ReturnCommonApi()
                    {
                        Status = true,
                        IdPlugin = DataCommon.EventBo_ConfirmArea,
                        Message = "Success Event Bo Confirm Store"
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
