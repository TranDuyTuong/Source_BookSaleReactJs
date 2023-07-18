using CommonConfiguration;
using CommonConfiguration.UserCommon;
using ConfigurationInterfaces.User;
using Microsoft.AspNetCore.Mvc;
using ModelConfiguration.M_Common;
using ModelConfiguration.M_Users;
using System.Diagnostics;
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
            var resultLogin = new ReturnLoginApi();

            if(dataConver != null)
            {
                // Check eventCode
                var checkEventCode = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (checkEventCode.Status == true)
                {
                    // handle login
                    resultLogin = await this.context.AuthorzirationUser(dataConver);
                    // conver to Json
                    var result = ConverToJson<ReturnLoginApi>.ConverObjectToJson(resultLogin);
                    return Ok(result);
                }
                else
                {
                    resultLogin.Status = false;
                    resultLogin.Token = null;
                    resultLogin.Message = DataCommon.MessageErrorEvent;
                    // conver to Json
                    var result = ConverToJson<ReturnLoginApi>.ConverObjectToJson(resultLogin);
                    return Ok(result);
                }
            }
            else
            {
                resultLogin.Status = false;
                resultLogin.Token = null;
                resultLogin.Message = DataCommon.MessageNullData;
                // Conver to Json
                var result = ConverToJson<ReturnLoginApi>.ConverObjectToJson(resultLogin);
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
            string result = null;
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
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
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

        /// <summary>
        /// SignOut
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut([FromBody] string request)
        {
            string result = null;
            // Conver Json to Object
            var dataConver = CommonConfiguration.ConverToJson<SignOutUser>.ConverJsonToObject(request);
            var resultSignOut = new ReturnCommonApi();

            // Check Null Token
            if(dataConver != null)
            {
                // Check Eventcode
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if(ev.Status == false)
                {
                    resultSignOut.Status = false;
                    resultSignOut.IdPlugin = DataCommon.EventError;
                    resultSignOut.Message = DataCommon.MessageErrorEvent;
                    result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(resultSignOut);
                }
                else
                {
                    // Check Token Null
                    if(dataConver.Token == null || dataConver.Token == "")
                    {
                        resultSignOut.Status = false;
                        resultSignOut.IdPlugin = DataCommon.EventError;
                        resultSignOut.Message = DataCommon.MessageNullToken;
                        result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(resultSignOut);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenContent = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        
                        if(tokenContent.Status == false) 
                        {
                            // Conver Object to json
                            result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(resultSignOut);
                        }
                        else
                        {
                            // SignOut DB
                            resultSignOut = await this.context.SignOut(dataConver);
                            result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(resultSignOut);
                        }

                    }
                }

            }
            else
            {
                resultSignOut.Status = false;
                resultSignOut.IdPlugin = DataCommon.EventError;
                resultSignOut.Message = DataCommon.MessageNullData;
                // Conver Object To Json
                result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(resultSignOut);
            }

            return Ok(result);
        }

        /// <summary>
        /// ValidationTokenUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("ValidationTokenUser")]
        public async Task<IActionResult> ValidationTokenUser([FromBody] string request)
        {
            string result = null;
            // Conver Json to Object
            var dataConver = ConverToJson<ResultCommonCheckToken>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
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
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(tokenResult);
                        }
                        else
                        {
                            // Token Success
                            ReturnCommonApi returnCheckToken = new ReturnCommonApi()
                            {
                                Status = true,
                                IdPlugin = DataCommon.EventSuccess,
                                Message = DataCommon.MessageToken
                            };
                            // Conver Object to json
                            result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(returnCheckToken);
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
