using CommonApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;
using TXTKikanSystem.Models;

namespace TXTKikanSystem.Controllers
{
    public class SignInController : Controller
    {
        private readonly ISignInUser context;

        public SignInController(ISignInUser _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// Login KikanSystem
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Concat string
            string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventLogin);

             var result = new LoginUser()
            {
                Email = email,
                Password = password,
                RememberMe = true,
                EventCode = eventCode
            };
            // conver object to json
            var jsonResult = CommonConverJsonToObject<LoginUser>.CoverObjectToJson(result);

            // Call Api
            var resultLogin = await this.context.ApiLoginUser(jsonResult);

            // Read Token
            var converJonToObject = CommonConverJsonToObject<ReturnLoginApi>.ConverJsonToObject(resultLogin);

            var infomationEmployer = new TokenViewModel();

            // Validation Content Data Json
            if(!converJonToObject.Status || converJonToObject.Token == null)
            {
                infomationEmployer.Token = null;
                infomationEmployer.MessageError = converJonToObject.Message;
            }
            else
            {
                var readToken = new FunctionLocation.FunctionReadToken();
                infomationEmployer = readToken.ReadToken(converJonToObject.Token);
            }


            return new JsonResult(infomationEmployer);
        }

        /// <summary>
        /// SignOut
        /// </summary>
        /// <param name="token"></param>
        /// <param name="UserID"></param>
        /// <param name="RoleID"></param>
        /// <param name="ExpirationDate"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SignOut(string token, string UserID, string RoleID, DateTime ExpirationDate)
        {
            // Concat string
            string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventSignOut);
            var result = new SignOutUser()
            {
                Token = token,
                UserID = UserID,
                RoleID = RoleID,
                ExpirationDate = ExpirationDate,
                EventCode = eventCode
            };
            // Conver Object to Json
            string jsonConver = CommonConverJsonToObject<SignOutUser>.CoverObjectToJson(result);
            
            // Call Api
            var resultData = await this.context.ApiLogoutUser(jsonConver);
            // Conver Json to object
            var signOutResult = CommonConverJsonToObject<ReturnCommonApi>.ConverJsonToObject(resultData);
            
            return new JsonResult(signOutResult);
        }

        [HttpGet]
        public IActionResult SignOutFail(string messageError)
        {
            ViewBag.messageError = messageError;
            return View();
        }

    }
}
