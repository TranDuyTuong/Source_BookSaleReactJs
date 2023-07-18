using CommonApi;
using System.Threading.Tasks;
using TXTKikanSystem.ApiConnections.IConnections;
using TXTKikanSystem.Models;

namespace TXTKikanSystem.FunctionLocation
{
    public class FunctionValidationToken
    {
        private readonly ICommonKikanSystem context;

        public FunctionValidationToken(ICommonKikanSystem _context)
        {
            this.context = _context;
        }

        public FunctionValidationToken()
        {
        }

        /// <summary>
        /// ValidationTokenEmployeer
        /// </summary>
        /// <param name="carshier"></param>
        /// <returns></returns>
        public async Task<bool> ValidationTokenEmployeer(string carshier)
        {
            // Concat string
            string eventCode = string.Concat(CommonApi.CommonEventCode.FistCode, CommonApi.CommonEventCode.EventValidationToken);
            // Check Carshier data
            string[] inputData = carshier.Split("*");
            var validationToken = new ResultCommonCheckToken()
            {
                UserID = inputData[0],
                RoleID = inputData[1],
                Token = inputData[2],
                EventCode = eventCode
            };
            // conver object to json
            var jsonResult = CommonConverJsonToObject<ResultCommonCheckToken>.CoverObjectToJson(validationToken);
            // Call Api
            var result = await this.context.ValidationEmployeerSignIn(jsonResult);
            // Conver Json to object
            var tokenValidationResult = CommonConverJsonToObject<ReturnCommonApi>.ConverJsonToObject(result);
            return tokenValidationResult.Status;
        }
    }
}
