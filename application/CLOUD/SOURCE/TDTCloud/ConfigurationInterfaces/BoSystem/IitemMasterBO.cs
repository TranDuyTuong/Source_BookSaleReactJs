using ModelConfiguration.M_Bo.ItemMasterData;
using ModelConfiguration.M_Bo.StoreData;
using ModelConfiguration.M_Common;
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
        Task<M_InitializaDataMaster> InitializaItemMaster(InitializaDataMaters request);

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

        /// <summary>
        /// GetAllItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListItemMaster> GetAllItemMaster(InitializaDataMaters request);

        /// <summary>
        /// GetItemMasterById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListItemMaster> GetItemMasterById(M_ListItemMaster request);

        /// <summary>
        /// GetItemMasterUpdatePriceById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListItemMaster> GetItemMasterUpdatePriceById(M_ListItemMaster request);

        /// <summary>
        /// ConfirmItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<M_ListItemMaster> ConfirmItemMaster(M_ListItemMaster request);
    }
}
