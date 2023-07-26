using System.Threading.Tasks;

namespace TXTKikanSystem.ApiConnections.IConnections
{
    public interface IimportDataKikaSystem
    {
        /// <summary>
        /// ImportDataByKikaSystem
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> GetTemplateByKikaSystemBook(string request);

        /// <summary>
        /// ImportDataIntoKikaSystem
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> ImportDataIntoKikaSystem(string request);
    }
}
