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
