using System.Threading.Tasks;

namespace TXTKikanSystem.ApiConnections.IConnections
{
    public interface ICommonKikanSystem
    {
        /// <summary>
        /// ValidationEmployeerSignIn
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> ValidationEmployeerSignIn(string request);
    }
}
