using ModelConfiguration.M_Bo.ItemMasterData;
using ModelConfiguration.M_Bo.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationInterfaces.BoSystem
{
    public interface IitemMasterBO
    {
        /// <summary>
        /// InitializaItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListStore> InitializaItemMaster(InitializaDataMaters request);

        /// <summary>
        /// SeachItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListItemMaster> SeachItemMaster(M_ListItemMaster request);

        /// <summary>
        /// ValidationItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListItemMaster> ValidationItemMaster(M_ListItemMaster request);
    }
}
