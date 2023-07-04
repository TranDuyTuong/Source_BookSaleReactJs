using Microsoft.AspNetCore.Mvc;
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
            var jsonResult = JsonHeper<LoginUser>.CoverObjectToJson(result);

            // Call Api
            var resultLogin = await this.context.ApiLoginUser(jsonResult);

            return new JsonResult(resultLogin);
        }

    }
}
