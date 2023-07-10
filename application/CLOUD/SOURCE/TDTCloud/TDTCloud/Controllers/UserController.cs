using CommonConfiguration;
using CommonConfiguration.UserCommon;
using ConfigurationInterfaces.User;
using Microsoft.AspNetCore.Mvc;
using ModelConfiguration.M_Common;
using ModelConfiguration.M_Users;
using System.Threading.Tasks;

namespace TDTCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserConfiguration context;

        public UserController(IUserConfiguration _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] string request)
        {
            // Conver Json to Object
            var dataConver = ConverToJson<LoginUser>.ConverJsonToObject(request);

            if(dataConver != null)
            {
                // Check eventCode
                var checkEventCode = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (checkEventCode.Status == true)
                {
                    // handle login
                    var login = await this.context.AuthorzirationUser(dataConver);

                    // conver to Json
                    var result = ConverToJson<ReturnLoginApi>.ConverObjectToJson(login);
                    return Ok(result);
                }
                else
                {
                    checkEventCode.Status = false;
                    checkEventCode.IdPlugin = DataCommon.EventError;
                    checkEventCode.Message = DataCommon.MessageErrorEvent;

                    // conver to Json
                    var result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(checkEventCode);
                    return Ok(result);
                }
            }
            else
            {
                var NullData = new ReturnCommonApi()
                {
                    Status = false,
                    IdPlugin = DataCommon.EventError,
                    Message = DataCommon.MessageNullData,
                };

                // Conver to Json
                var result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(NullData);
                return Ok(result);
            }
        }

        /// <summary>
        /// Regiter User
        /// </summary>
        /// <param name="request"></param>
        /// <param name="EventCode"></param>
        /// <returns></returns>
        [HttpPost("Regiter")]
        public async Task<IActionResult> Regiter([FromBody] string request)
        {
            string result;
            // Conver Json to Object
            var dataConver = ConverToJson<RegiterUser>.ConverJsonToObject(request);
            if(dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);
                
                if(ev.Status == true)
                {
                    // Check Token Null
                    if(dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new ReturnCommonApi()
                        {
                            Status = false,
                            IdPlugin = DataCommon.EventError,
                            Message = DataCommon.MessageNullToken
                        };

                        // Conver Object to json
                        result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, dataConver.EventCode);
                        if(tokenResult.Status == false)
                        {
                            result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(tokenResult);
                        }
                        else
                        {
                            // Regiter To DB
                            var resultRegiter = await this.context.RegiterUser(dataConver);
                            // Conver Object to json
                            result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(resultRegiter);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new ReturnCommonApi()
                    {
                        Status = false,
                        IdPlugin = DataCommon.EventError,
                        Message = DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new ReturnCommonApi()
                {
                    Status = false,
                    IdPlugin = DataCommon.EventError,
                    Message = DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

    }
}
