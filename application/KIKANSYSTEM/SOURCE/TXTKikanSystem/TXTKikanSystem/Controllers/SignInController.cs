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
        public async Task<IActionResult> Login(LoginUser request) {

            var result = new LoginUser()
            {
                Email = request.Email,
                Password = request.Password,
                RememberMe = true,
                EventCode = CommonApi.CommonEventCode.EventLogin
            };
            // conver objec to json
            var jsonResult = JsonHeper<LoginUser>.CoverObjectToJson(result);
            // Call Api
            var resultLogin = await this.context.ApiLoginUser(jsonResult);

            return new JsonResult(0);
        }

    }
}
