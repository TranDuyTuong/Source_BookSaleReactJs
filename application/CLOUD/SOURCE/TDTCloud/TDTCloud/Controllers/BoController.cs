using CommonConfiguration.UserCommon;
using CommonConfiguration;
using ConfigurationInterfaces.BoSystem;
using Microsoft.AspNetCore.Mvc;
using ModelConfiguration.M_Bo.AreaData;
using ModelConfiguration.M_KikanSystem;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelConfiguration.M_Bo.StoreData;
using ModelConfiguration.M_Bo.ItemMasterData;
using ModelConfiguration.M_Bo.AuthorData;

namespace TDTCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoController : Controller
    {
        private readonly IAreaBO areaBO;
        private readonly IStoreBO storeBO;
        private readonly IitemMasterBO itemMasterBO;
        private readonly IAuthorBO authorBO;
        public BoController(IAreaBO _areaBO, IStoreBO _storeBO, IitemMasterBO _itemMasterBO, IAuthorBO _authorBO)
        {
            this.areaBO = _areaBO;
            this.storeBO = _storeBO;
            this.itemMasterBO = _itemMasterBO;
            this.authorBO = _authorBO;
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

        /// <summary>
        /// InitializaItemMaster
        /// </summary>
        /// <param name="initializa"></param>
        /// <returns></returns>
        [HttpPost("InitializaItemMaster")]
        public async Task<IActionResult> InitializaItemMaster([FromForm] InitializaDataMaters initializa)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<InitializaDataMaters>.ConverObjectToJson(initializa);

            // Conver Json to Object
            var dataConver = ConverToJson<InitializaDataMaters>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_InitializaDataMaster()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_InitializaDataMaster>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_InitializaDataMaster()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_InitializaDataMaster>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Get Initializa itemMaster To DB
                            var getDataInitializa = await this.itemMasterBO.InitializaItemMaster(dataConver);
                            // Conver Object to json
                            result = ConverToJson<M_InitializaDataMaster>.ConverObjectToJson(getDataInitializa);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_InitializaDataMaster()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_InitializaDataMaster>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_InitializaDataMaster()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_InitializaDataMaster>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// SeachItemMaster
        /// </summary>
        /// <param name="seachItemMaster"></param>
        /// <returns></returns>
        [HttpPost("SeachItemMaster")]
        public async Task<IActionResult> SeachItemMaster([FromForm] M_ListItemMaster seachItemMaster)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<M_ListItemMaster>.ConverObjectToJson(seachItemMaster);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListItemMaster>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListItemMaster()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListItemMaster()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach ItemMaster To DB
                            var seachResult = await this.itemMasterBO.SeachItemMaster(dataConver);
                            // Conver Object to json
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(seachResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListItemMaster()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListItemMaster()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// SeachUpdateItemMaster
        /// </summary>
        /// <param name="seachItemMaster"></param>
        /// <returns></returns>
        [HttpPost("SeachUpdateItemMaster")]
        public async Task<IActionResult> SeachUpdateItemMaster([FromForm] M_ListItemMaster seachItemMaster)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<M_ListItemMaster>.ConverObjectToJson(seachItemMaster);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListItemMaster>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListItemMaster()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListItemMaster()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach Update ItemMaster To DB
                            var seachResult = await this.itemMasterBO.GetItemMasterById(dataConver);
                            // Conver Object to json
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(seachResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListItemMaster()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListItemMaster()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// SeachUpdatePriceItemMaster
        /// </summary>
        /// <param name="seachItemMaster"></param>
        /// <returns></returns>
        [HttpPost("SeachUpdatePriceItemMaster")]
        public async Task<IActionResult> SeachUpdatePriceItemMaster([FromForm] M_ListItemMaster seachItemMaster)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<M_ListItemMaster>.ConverObjectToJson(seachItemMaster);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListItemMaster>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListItemMaster()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListItemMaster()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach Update ItemMaster To DB
                            var seachResult = await this.itemMasterBO.GetItemMasterUpdatePriceById(dataConver);
                            // Conver Object to json
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(seachResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListItemMaster()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListItemMaster()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// GetAllItemMaster
        /// </summary>
        /// <param name="getItemMaster"></param>
        /// <returns></returns>
        [HttpPost("GetAllItemMaster")]
        public async Task<IActionResult> GetAllItemMaster([FromForm] InitializaDataMaters getItemMaster)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<InitializaDataMaters>.ConverObjectToJson(getItemMaster);

            // Conver Json to Object
            var dataConver = ConverToJson<InitializaDataMaters>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListItemMaster()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListItemMaster()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach Update ItemMaster To DB
                            var getItemMasterResutl = await this.itemMasterBO.GetAllItemMaster(dataConver);
                            // Conver Object to json
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(getItemMasterResutl);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListItemMaster()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListItemMaster()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// ValidationItemMaster
        /// </summary>
        /// <param name="itemMaster"></param>
        /// <returns></returns>
        [HttpPost("ValidationItemMaster")]
        public async Task<IActionResult> ValidationItemMaster([FromForm] M_ListItemMaster itemMaster)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<M_ListItemMaster>.ConverObjectToJson(itemMaster);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListItemMaster>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListItemMaster()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListItemMaster()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach ItemMaster To DB
                            var resultValidation = await this.itemMasterBO.ValidationItemMaster(dataConver);
                            // Conver Object to json
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(resultValidation);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListItemMaster()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListItemMaster()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// ConfirmItemMaster
        /// </summary>
        /// <param name="itemMaster"></param>
        /// <returns></returns>
        [HttpPost("ConfirmItemMaster")]
        public async Task<IActionResult> ConfirmItemMaster([FromForm] M_ListItemMaster itemMaster)
        {
            string result = null;
            // Conver json to list ItemMaster Insert
            List<M_ItemMaster> request = ConverToJson<List<M_ItemMaster>>.ConverJsonToObject(itemMaster.KeySeach);

            // Conver Json to Object
            itemMaster.ListItemMaster = request;

            if (itemMaster != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(itemMaster.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (itemMaster.Token == null || itemMaster.Token == "")
                    {
                        var tokenNull = new M_ListItemMaster()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(itemMaster.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListItemMaster()
                            {
                                Status = tokenResult.Status,
                                Token = itemMaster.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Confirm ItemMaster To DB
                            var confirmResult = await this.itemMasterBO.ConfirmItemMaster(itemMaster);
                            // Conver Object to json
                            result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(confirmResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListItemMaster()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = itemMaster.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListItemMaster()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = itemMaster.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListItemMaster>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }

        /// <summary>
        /// SeachAuthor
        /// </summary>
        /// <param name="seachStore"></param>
        /// <returns></returns>
        [HttpPost("SeachAuthor")]
        public async Task<IActionResult> SeachAuthor([FromForm] M_ListAuthor seachStore)
        {
            string result = null;
            // Conver Object to Json
            string request = ConverToJson<M_ListAuthor>.ConverObjectToJson(seachStore);

            // Conver Json to Object
            var dataConver = ConverToJson<M_ListAuthor>.ConverJsonToObject(request);
            if (dataConver != null)
            {
                // Check event code
                var ev = ValidationEventCode.CheckEventCode(dataConver.EventCode);

                if (ev.Status == true)
                {
                    // Check Token Null
                    if (dataConver.Token == null || dataConver.Token == "")
                    {
                        var tokenNull = new M_ListAuthor()
                        {
                            Status = false,
                            MessageError = CommonConfiguration.DataCommon.MessageNullToken

                        };

                        // Conver Object to json
                        result = ConverToJson<M_ListAuthor>.ConverObjectToJson(tokenNull);
                    }
                    else
                    {
                        // Check Content Token
                        var f_CheckValidationToken = new ValidationToken();
                        var tokenResult = f_CheckValidationToken.ReadContentToken(dataConver.Token, ev.IdPlugin);
                        if (tokenResult.Status == false)
                        {
                            var resultContent = new M_ListAuthor()
                            {
                                Status = tokenResult.Status,
                                Token = dataConver.Token,
                                EventCode = DataCommon.EventError

                            };
                            result = ConverToJson<M_ListAuthor>.ConverObjectToJson(resultContent);
                        }
                        else
                        {
                            // Seach Area To DB
                            var seachResult = await this.authorBO.SeachAuthor(dataConver.KeySeach, dataConver.UserID, dataConver.RoleID, dataConver.Token, ev.IdPlugin, dataConver.CompanyCode);
                            // Conver Object to json
                            result = ConverToJson<M_ListAuthor>.ConverObjectToJson(seachResult);
                        }
                    }
                }
                else
                {
                    var errorEventCode = new M_ListAuthor()
                    {
                        Status = false,
                        EventCode = DataCommon.EventError,
                        Token = dataConver.Token,
                        MessageError = CommonConfiguration.DataCommon.MessageErrorEvent
                    };

                    // Conver Object to Json
                    result = ConverToJson<M_ListAuthor>.ConverObjectToJson(errorEventCode);
                }
            }
            else
            {
                var nullData = new M_ListAuthor()
                {
                    Status = false,
                    EventCode = DataCommon.EventError,
                    Token = dataConver.Token,
                    MessageError = CommonConfiguration.DataCommon.MessageNullData
                };

                // Conver Object to Json
                result = ConverToJson<M_ListAuthor>.ConverObjectToJson(nullData);
            }
            return Ok(result);
        }
    }
}
