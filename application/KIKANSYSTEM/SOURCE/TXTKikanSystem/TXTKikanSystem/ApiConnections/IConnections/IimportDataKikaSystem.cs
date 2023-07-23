using System.Threading.Tasks;

namespace TXTKikanSystem.ApiConnections.IConnections
{
    public interface IimportDataKikaSystem
    {
        Task<string> ImportDataByKikaSystem(string request);
    }
}
