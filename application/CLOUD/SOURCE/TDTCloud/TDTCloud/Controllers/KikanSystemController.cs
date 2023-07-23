﻿using CommonConfiguration;
using CommonConfiguration.UserCommon;
using ConfigurationInterfaces.KikanSystem;
using Microsoft.AspNetCore.Mvc;
using ModelConfiguration.M_Common;
using ModelConfiguration.M_KikanSystem;
using System.Threading.Tasks;

namespace TDTCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KikanSystemController : Controller
    {
        private readonly IHomeInitialization context;
        private readonly IimportDataKikanSystem importData;

        public KikanSystemController(IHomeInitialization _context, IimportDataKikanSystem _importData)
        {
            this.context = _context;
            this.importData = _importData;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("DataInitializationHome")]
        public async Task<IActionResult> DataInitializationHome([FromBody] string request)
        {
            string result = null;
            // Conver Json to Object
            var dataConver = ConverToJson<InitializationDataHome>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new InitializationDataHome()
                        {
                            Status = false
                        };

                        // Conver Object to json
                        result = ConverToJson<InitializationDataHome>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new InitializationDataHome()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<InitializationDataHome>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // InitializationDataHome To DB
                            var resultInitialization = await this.context.initializationDataHome(dataConver.Company, dataConver.AreaCode, dataConver.StoreCode);
                            resultInitialization.Token = dataConver.Token;
                            // Conver Object to json
                            result = ConverToJson<InitializationDataHome>.ConverObjectToJson(resultInitialization);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new InitializationDataHome()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token
                    };

                    // Conver Object to Json
                    result = ConverToJson<InitializationDataHome>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new InitializationDataHome()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token
                };

                // Conver Object to Json
                result = ConverToJson<InitializationDataHome>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// Get Template Import Books
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("GetTemplateImportBooks")]
        public async Task<IActionResult> GetTemplateImportBooks([FromBody] string request)
        {
            string result = null;
            // Conver Json to Object
            var dataConver = ConverToJson<TemplateImportKikanSystem>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new TemplateImportKikanSystem()
                        {
                            Status = false
                        };

                        // Conver Object to json
                        result = ConverToJson<TemplateImportKikanSystem>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new TemplateImportKikanSystem()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<TemplateImportKikanSystem>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // ImportData To DB
                            dataConver.EventCode = ev.IdPlugin;
                           var resultTemplate = await this.importData.GetTemplateImport(dataConver);
                            resultTemplate.Token = dataConver.Token;
                            // Conver Object to json
                            result = ConverToJson<TemplateImportKikanSystem>.ConverObjectToJson(resultTemplate);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new TemplateImportKikanSystem()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token
                    };

                    // Conver Object to Json
                    result = ConverToJson<TemplateImportKikanSystem>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new TemplateImportKikanSystem()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token
                };

                // Conver Object to Json
                result = ConverToJson<TemplateImportKikanSystem>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

    }
}