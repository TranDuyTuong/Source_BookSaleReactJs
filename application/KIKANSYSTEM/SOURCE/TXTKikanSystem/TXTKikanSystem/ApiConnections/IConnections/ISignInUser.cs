using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TXTKikanSystem.ApiConnections.IConnections
{
    public interface ISignInUser
    {
        /// <summary>
        /// ApiLoginUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> ApiLoginUser(string request);
    }
}
