using System.Threading.Tasks;

namespace TXTKikanSystem.ApiConnections.IConnections
{
    public interface IHomeKikanSystem
    {
        /// <summary>
        /// ValidationEmployeerSignIn
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> Initialization(string request);
    }
}
