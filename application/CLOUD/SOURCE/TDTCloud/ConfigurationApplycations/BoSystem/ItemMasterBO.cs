using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.BoSystem;
using ConfigurationInterfaces.DataCommon;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Bo.ItemMasterData;
using ModelConfiguration.M_Bo.StoreData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace ConfigurationApplycations.BoSystem
{
    public class ItemMasterBO : IitemMasterBO
    {
        private readonly ContextFE context;
        private readonly IContactCommon contactCommon;
        public ItemMasterBO(ContextFE _context, IContactCommon _contactCommon)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
        }

        /// <summary>
        /// InitializaItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_ListStore> InitializaItemMaster(InitializaDataMaters request)
        {
            var result = new M_ListStore();
            try
            {
                // Check CompanyCode
                bool isCompanyCode = this.contactCommon.ValidationCompanyCode(request.CompanyCode);

                if (isCompanyCode == true)
                {
                    // Check Role User Handle
                    bool isRole = await this.contactCommon.ValidationRoleUserLimit(request.RoleID, request.UserID, request.EventCode);

                    if (isRole == true)
                    {
                        // Don't have role handle
                        result.Token = request.Token;
                        result.UserID = request.UserID;
                        result.RoleID = request.RoleID;
                        result.EventCode = request.EventCode;
                        result.TotalStore = 0;
                        result.KeySeach = null;
                        result.CompanyCode = request.CompanyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get All Store in DB
                        var queryStore = await this.context.stores.Where(x => x.IsDeleteFlag == false).ToArrayAsync();

                        if(queryStore.Any() == true)
                        {
                            List<M_Store> storeList = new List<M_Store>();

                            foreach (var store in queryStore)
                            {
                                var storeItem = new M_Store()
                                {
                                    StoreCode = store.StoreCode,
                                    Description = store.Description,                                  
                                };
                                storeList.Add(storeItem);
                            }

                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalStore = 0;
                            result.KeySeach = null;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = true;
                            result.MessageError = null;
                            result.ListStore = storeList;
                        }
                        else
                        {
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalStore = 0;
                            result.KeySeach = null;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = false;
                            result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                        }
                    }
                }
                else
                {
                    // Don't Find CompanyCode
                    result.Token = request.Token;
                    result.UserID = request.UserID;
                    result.RoleID = request.RoleID;
                    result.EventCode = request.EventCode;
                    result.TotalStore = 0;
                    result.KeySeach = null;
                    result.CompanyCode = request.CompanyCode;
                    result.Status = false;
                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindCompanyCode;

                }
            }
            catch (Exception ex)
            {
                result.Token = request.Token;
                result.UserID = request.UserID;
                result.RoleID = request.RoleID;
                result.EventCode = request.EventCode;
                result.TotalStore = 0;
                result.KeySeach = null;
                result.CompanyCode = request.CompanyCode;
                result.Status = false;
                result.MessageError = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// SeachItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_ListItemMaster> SeachItemMaster(M_ListItemMaster request)
        {
            var result = new M_ListItemMaster();
            try
            {
                // Check CompanyCode
                bool isCompanyCode = this.contactCommon.ValidationCompanyCode(request.CompanyCode);

                if (isCompanyCode == true)
                {
                    // Check Role User Handle
                    bool isRole = await this.contactCommon.ValidationRoleUserLimit(request.RoleID, request.UserID, request.EventCode);

                    if (isRole == true)
                    {
                        // Don't have role handle
                        result.Token = request.Token;
                        result.UserID = request.UserID;
                        result.RoleID = request.RoleID;
                        result.EventCode = request.EventCode;
                        result.TotalItemMaster = 0;
                        result.KeySeach = null;
                        result.CompanyCode = request.CompanyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get All ItemMaster In DB
                        var queryItemMaster = from itemMaster in this.context.itemMasters
                                              where (
                                              itemMaster.CompanyCode == request.CompanyCode &&
                                              itemMaster.IsDeleteFlag == false &&
                                              itemMaster.IsSale == true
                                              )
                                              select new { itemMaster };

                        // List Result ItemMaster Affter Query
                        var listResultQuery = await queryItemMaster.Select(x => new M_ItemMaster()
                        {
                            CompanyCode = x.itemMaster.CompanyCode,
                            StoreCode = x.itemMaster.StoreCode,
                            ItemCode = x.itemMaster.ItemCode,
                            ApplyDate = x.itemMaster.ApplyDate,
                            Description = x.itemMaster.Description,
                            DescriptionShort = x.itemMaster.DescriptionShort,
                            DescriptionLong = x.itemMaster.DescriptionLong,
                            PriceOrigin = x.itemMaster.PriceOrigin,
                            PercentDiscount = x.itemMaster.PercentDiscount,
                            priceSale = x.itemMaster.priceSale,
                            QuantityDiscountID = x.itemMaster.QuantityDiscountID,
                            PairDiscountID = x.itemMaster.PairDiscountID,
                            SpecialDiscountID = x.itemMaster.SpecialDiscountID,
                            Quantity = x.itemMaster.Quantity,
                            Viewer = x.itemMaster.Viewer,
                            Buy = x.itemMaster.Buy,
                            CategoryItemMasterID = x.itemMaster.CategoryItemMasterID,
                            AuthorID = x.itemMaster.AuthorID,
                            DateCreate = x.itemMaster.DateCreate,
                            IssuingCompanyID = x.itemMaster.IssuingCompanyID,
                            PublicationDate = x.itemMaster.PublicationDate,
                            size = x.itemMaster.size,
                            PageNumber = x.itemMaster.PageNumber,
                            PublishingCompanyID = x.itemMaster.PublishingCompanyID,
                            IsSale = x.itemMaster.IsSale,
                            LastUpdateDate = x.itemMaster.LastUpdateDate,
                            Note = x.itemMaster.Note,
                            HeadquartersLastUpdateDateTime = x.itemMaster.HeadquartersLastUpdateDateTime,
                            IsDeleteFlag = x.itemMaster.IsDeleteFlag,
                            UserID = x.itemMaster.UserID,
                            TaxGroupCodeID = x.itemMaster.TaxGroupCodeID,
                            TypeOf = null,
                            OldType = null,
                        }).ToListAsync();

                        // Get itemMaster Have Applydate Max
                        List<M_ItemMaster> listItemMaster = new List<M_ItemMaster>();
                        string state_ItemMasterCode = null;

                        foreach(var item in listResultQuery)
                        {
                            if(state_ItemMasterCode == item.ItemCode)
                            {
                                continue;
                            }
                            else
                            {
                                // Count Recod ItemCode
                                var itemData = listResultQuery.Where(x => x.ItemCode == item.ItemCode).ToList();

                                // If itemCode more than 1 recod
                                if (itemData.Count > 1)
                                {
                                    // Get Recod Have Max ApplyDate
                                    var maxApplydate = itemData.OrderByDescending(x => x.ApplyDate).Take(1).First();
                                    listItemMaster.Add(maxApplydate);
                                    state_ItemMasterCode = maxApplydate.ItemCode;
                                }
                                else
                                {
                                    listItemMaster.Add(itemData.First());
                                }
                            }
                        }

                        if(listItemMaster.Any() == true)
                        {
                            // Count ItemMaster
                            int  TotalItemMaster = listItemMaster.Count();
                            // Find ItemMaster
                            // 1) Seach Have CompanyCode, Not ItemCode, Not StoreCodde
                            if(request.CompanyCode != null && (request.KeySeach == null || request.KeySeach == "") && request.StoreCode == null)
                            {
                                // More Than 100 Recol
                                if(TotalItemMaster > CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = CommonConfiguration.DataCommon.MaxRecol;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageErrorMoreThan100Recol;
                                    result.Status = true;
                                    result.ListItemMaster = listItemMaster.OrderByDescending(x => x.ApplyDate).Take(CommonConfiguration.DataCommon.MaxRecol).ToList();
                                }else if(TotalItemMaster < CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = TotalItemMaster;
                                    result.MessageError = null;
                                    result.Status = true;
                                    result.ListItemMaster = listItemMaster.OrderByDescending(x => x.ApplyDate).Take(CommonConfiguration.DataCommon.MaxRecol).ToList();
                                }
                            }

                            // 2) Seach Have CompanyCode, Have StoreCode, Not ItemCode
                            if(request.CompanyCode != null && request.StoreCode != null && (request.KeySeach == null || request.KeySeach == ""))
                            {
                                // Get ItemMaster By StoreCode
                                var ItemMasterByStoreCode = listItemMaster.Where(x => x.StoreCode == request.StoreCode).ToList();

                                // More Than 100 Recol
                                if (ItemMasterByStoreCode.Count() > CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = CommonConfiguration.DataCommon.MaxRecol;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageErrorMoreThan100Recol;
                                    result.Status = true;
                                    result.ListItemMaster = ItemMasterByStoreCode.OrderByDescending(x => x.ApplyDate).Take(CommonConfiguration.DataCommon.MaxRecol).ToList();
                                }
                                else if (ItemMasterByStoreCode.Count() < CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = ItemMasterByStoreCode.Count();
                                    result.MessageError = null;
                                    result.Status = true;
                                    result.ListItemMaster = ItemMasterByStoreCode.OrderByDescending(x => x.ApplyDate).Take(CommonConfiguration.DataCommon.MaxRecol).ToList();
                                }
                            }

                            // 3) Seach Have CompanyCode, Have ItemCode, Not StoreCode
                            if(request.CompanyCode != null && request.KeySeach != null && request.StoreCode == null)
                            {
                                // Get ItemMaster By ItemCode
                                var ItemMasterData = listItemMaster.FirstOrDefault(x => x.ItemCode == request.KeySeach);
                                
                                // Find ItemCode
                                if(ItemMasterData != null)
                                {
                                    result.TotalItemMaster = 0;
                                    result.MessageError = null;
                                    result.Status = true;
                                    result.ListItemMaster.Add(ItemMasterData);
                                }
                                else
                                {
                                    result.CompanyCode = request.CompanyCode;
                                    result.Status = false;
                                    result.StoreCode = request.StoreCode;
                                    result.EventCode = request.EventCode;
                                    result.UserID = request.UserID;
                                    result.RoleID = request.RoleID;
                                    result.KeySeach = request.KeySeach;
                                    result.Token = request.Token;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                                    result.ListItemMaster = null;
                                }
                            }

                            // 4) Seach Have Companycode, Have ItemCoe, Have StoreCode
                            if(request.CompanyCode != null && request.KeySeach != null && request.StoreCode != null)
                            {
                                // Get ItemMaster By StoreCode
                                var ItemMasterByStoreCode = listItemMaster.Where(x => x.StoreCode == request.StoreCode).ToList();
                                // Get ItemMaster By ItemCode
                                var ItemMasterData = ItemMasterByStoreCode.FirstOrDefault(x => x.ItemCode == request.KeySeach);

                                // Find ItemCode
                                if (ItemMasterData != null)
                                {
                                    result.TotalItemMaster = 0;
                                    result.MessageError = null;
                                    result.Status = true;
                                    result.ListItemMaster.Add(ItemMasterData);
                                }
                                else
                                {
                                    result.CompanyCode = request.CompanyCode;
                                    result.Status = false;
                                    result.StoreCode = request.StoreCode;
                                    result.EventCode = request.EventCode;
                                    result.UserID = request.UserID;
                                    result.RoleID = request.RoleID;
                                    result.KeySeach = request.KeySeach;
                                    result.Token = request.Token;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                                    result.ListItemMaster = null;
                                }
                            }

                            // Set Data Infomation Result
                            if(result.Status == true)
                            {
                                result.CompanyCode = request.CompanyCode;
                                result.StoreCode = request.StoreCode;
                                result.EventCode = request.EventCode;
                                result.UserID = request.UserID;
                                result.RoleID = request.RoleID;
                                result.KeySeach = request.KeySeach;
                                result.Token = request.Token;
                            }
                        }
                        else
                        {
                            // Not Find ItemMaster
                            result.CompanyCode = request.CompanyCode;
                            result.Status = false;
                            result.StoreCode = request.StoreCode;
                            result.EventCode = request.EventCode;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.KeySeach = request.KeySeach;
                            result.Token = request.Token;
                            result.MessageError = CommonConfiguration.DataCommon.MessageNotFindData;
                            result.ListItemMaster = null;
                        }
                                              
                    }
                }
                else
                {
                    // Don't Find CompanyCode
                    result.Token = request.Token;
                    result.UserID = request.UserID;
                    result.RoleID = request.RoleID;
                    result.EventCode = request.EventCode;
                    result.TotalItemMaster = 0;
                    result.KeySeach = null;
                    result.CompanyCode = request.CompanyCode;
                    result.Status = false;
                    result.MessageError = CommonConfiguration.DataCommon.MessageNotFindCompanyCode;

                }
            }
            catch (Exception ex)
            {
                result.Token = request.Token;
                result.UserID = request.UserID;
                result.RoleID = request.RoleID;
                result.EventCode = request.EventCode;
                result.TotalItemMaster = 0;
                result.KeySeach = null;
                result.CompanyCode = request.CompanyCode;
                result.Status = false;
                result.MessageError = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// ValidationItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<M_ListItemMaster> ValidationItemMaster(M_ListItemMaster request)
        {
            throw new NotImplementedException();
        }
    }
}
