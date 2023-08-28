using CommonConfiguration.UserCommon;
using CommonConfiguration;
using ConfigurationInterfaces.BoSystem;
using Microsoft.AspNetCore.Mvc;
using ModelConfiguration.M_Bo.AreaData;
using ModelConfiguration.M_KikanSystem;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelConfiguration.M_Bo.StoreData;

namespace TDTCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoController : Controller
    {
        private readonly IAreaBO areaBO;
        private readonly IStoreBO storeBO;
        public BoController(IAreaBO _areaBO, IStoreBO _storeBO)
        {
            this.areaBO = _areaBO;
            this.storeBO = _storeBO;
        }

        /// <summary>
        /// SeachArea
        /// </summary>
        /// <param name="seachArea"></param>
        /// <returns></returns>
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
                            var seachResult = await this.areaBO.SeachArea(dataConver.KeySeach, dataConver.UserID, dataConver.RoleID, dataConver.Token, ev.IdPlugin, dataConver.CompanyCode);
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

        /// <summary>
        /// ConfirmArea
        /// </summary>
        /// <param name="confirmArea"></param>
        /// <returns></returns>
        [HttpPost("ConfirmArea")]
        public async Task<IActionResult> ConfirmArea([FromForm] M_ListArea confirmArea)
        {
            string result = null;
            // Conver Json List Area to ListArea
            var listArea = ConverToJson<List<M_Area>>.ConverJsonToObject(confirmArea.KeySeach);

            // Conver Object to Json
            string request = ConverToJson<M_ListArea>.ConverObjectToJson(confirmArea);

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
                                EventCode = DataCommon.EventError,
                                MessageError = tokenResult.Message

                            };
                            result = ConverToJson<M_ListArea>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            dataConver.ListArea = listArea;
                            dataConver.KeySeach = null;

                            // Confirm Area To DB
                            var seachResult = await this.areaBO.ConfirmArea(dataConver);
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

        /// <summary>
        /// SeachStore
        /// </summary>
        /// <param name="seachStore">seachStore</param>
        /// <returns></returns>
        [HttpPost("SeachStore")]
        public async Task<IActionResult> SeachStore([FromForm] M_ListStore seachStore)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<M_ListStore>.ConverObjectToJson(seachStore);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListStore>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListStore()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListStore>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListStore()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListStore>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach Area To DB
                            var seachResult = await this.storeBO.SeachStore(dataConver.KeySeach, dataConver.UserID, dataConver.RoleID, dataConver.Token, ev.IdPlugin, dataConver.CompanyCode);
                            // Conver Object to json
                            result = ConverToJson<M_ListStore>.ConverObjectToJson(seachResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListStore()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListStore>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListStore()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListStore>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// DetailStore
        /// </summary>
        /// <param name="storeCode"></param>
        /// <returns></returns>
        [HttpPost("DetailStore")]
        public async Task<IActionResult> DetailStore([FromForm] M_ListStore storeCode)
        {
            string result = null;

            // Conver Object to Json
            string request = ConverToJson<M_ListStore>.ConverObjectToJson(storeCode);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListStore>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListStore()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListStore>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListStore()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListStore>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Detail store To DB
                            var seachResult = await this.storeBO.DetailStore(dataConver.KeySeach, dataConver.UserID, dataConver.RoleID, dataConver.Token, ev.IdPlugin, dataConver.CompanyCode);
                            // Conver Object to json
                            result = ConverToJson<M_ListStore>.ConverObjectToJson(seachResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListStore()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListStore>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListStore()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListStore>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// ConfirmStore
        /// </summary>
        /// <param name="confirmStore"></param>
        /// <returns></returns>
        [HttpPost("ConfirmStore")]
        public async Task<IActionResult> ConfirmStore([FromForm] M_ListStore confirmStore)
        {
            string result = null;
            // Conver Json Seach to ListStore
            var listStore = ConverToJson<List<M_Store>>.ConverJsonToObject(confirmStore.KeySeach);

            // Conver Object to Json
            string request = ConverToJson<M_ListStore>.ConverObjectToJson(confirmStore);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListStore>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListStore()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListStore>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListStore()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListStore>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            dataConver.ListStore = listStore;
                            dataConver.KeySeach = null;
                            // Confirm store To DB
                            var confirmResult = await this.storeBO.ConfirmStore(dataConver);
                            // Conver Object to json
                            result = ConverToJson<M_ListStore>.ConverObjectToJson(confirmResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListStore()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListStore>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListStore()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListStore>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

    }
}
