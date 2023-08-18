﻿using CommonConfiguration.UserCommon;
using CommonConfiguration;
using ConfigurationInterfaces.BoSystem;
using Microsoft.AspNetCore.Mvc;
using ModelConfiguration.M_Bo.AreaData;
using ModelConfiguration.M_KikanSystem;
using System.Threading.Tasks;

namespace TDTCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoController : Controller
    {
        private readonly IAreaBO context;
        public BoController(IAreaBO _context)
        {
            this.context = _context;
        }

        [HttpPost("SeachArea")]
        public async Task<IActionResult> SeachArea([FromForm] M_ListArea seachArea)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<M_ListArea>.ConverObjectToJson(seachArea);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListArea>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListArea()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListArea>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListArea()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListArea>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach Area To DB
                            var seachResult = await this.context.SeachArea(dataConver.KeySeach, dataConver.UserID, dataConver.RoleID, dataConver.Token, ev.IdPlugin, dataConver.CompanyCode);
                            // Conver Object to json
                            result = ConverToJson<M_ListArea>.ConverObjectToJson(seachResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListArea()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListArea>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListArea()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListArea>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

    }
}