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
        public async Task<IActionResult> Login(string request)
        {
            //// Check eventCode
            //var checkEventCode = ValidationEventCode.CheckEventCode(request.EventCode);
            //if (checkEventCode.Status == true) 
            //{
            //    var login = await this.context.AuthorzirationUser(request);
            //    // converJson
            //    var result = ConverToJson<ReturnLoginApi>.ConverObjectToJson(login);
            //    return new JsonResult(result);
            //}
            //else
            //{
            //    // converJson
            //    var result = ConverToJson<ReturnCommonApi>.ConverObjectToJson(checkEventCode);
            //    return new JsonResult(checkEventCode);
            //}
            return Ok();
        }

        /// <summary>
        /// Regiter User
        /// </summary>
        /// <param name="request"></param>
        /// <param name="EventCode"></param>
        /// <returns></returns>
        [HttpPost("Regiter")]
        public async Task<IActionResult> Regiter(RegiterUser request)
        {
            return Ok();
        }

    }
}
