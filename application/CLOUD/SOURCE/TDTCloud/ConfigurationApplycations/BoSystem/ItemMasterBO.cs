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
                                              select new M_ItemMaster()
                                              {
                                                  CompanyCode = itemMaster.CompanyCode,
                                                  StoreCode = itemMaster.StoreCode,
                                                  ItemCode = itemMaster.ItemCode,
                                                  ApplyDate = itemMaster.ApplyDate,
                                                  Description = itemMaster.Description,
                                                  DescriptionShort = itemMaster.DescriptionShort,
                                                  DescriptionLong = itemMaster.DescriptionLong,
                                                  PriceOrigin = itemMaster.PriceOrigin,
                                                  PercentDiscount = itemMaster.PercentDiscount,
                                                  priceSale = itemMaster.priceSale,
                                                  QuantityDiscountID = itemMaster.QuantityDiscountID,
                                                  PairDiscountID = itemMaster.PairDiscountID,
                                                  SpecialDiscountID = itemMaster.SpecialDiscountID,
                                                  Quantity = itemMaster.Quantity,
                                                  Viewer = itemMaster.Viewer,
                                                  Buy = itemMaster.Buy,
                                                  CategoryItemMasterID = itemMaster.CategoryItemMasterID,
                                                  AuthorID = itemMaster.AuthorID,
                                                  DateCreate = itemMaster.DateCreate,
                                                  IssuingCompanyID = itemMaster.IssuingCompanyID,
                                                  PublicationDate = itemMaster.PublicationDate,
                                                  size = itemMaster.size,
                                                  PageNumber = itemMaster.PageNumber,
                                                  PublishingCompanyID = itemMaster.PublishingCompanyID,
                                                  IsSale = itemMaster.IsSale,
                                                  LastUpdateDate = itemMaster.LastUpdateDate,
                                                  Note = itemMaster.Note,
                                                  HeadquartersLastUpdateDateTime = itemMaster.HeadquartersLastUpdateDateTime,
                                                  IsDeleteFlag = itemMaster.IsDeleteFlag,
                                                  UserID = itemMaster.UserID,
                                                  TaxGroupCodeID = itemMaster.TaxGroupCodeID,
                                                  TypeOf = null,
                                                  OldType = null,
                                              };

                        // Get itemMaster Have Applydate Max
                        List<M_ItemMaster> listItemMaster = new List<M_ItemMaster>();

                        foreach(var item in queryItemMaster)
                        {
                            // Count Recod ItemCode
                            var itemData = queryItemMaster.Where(x => x.ItemCode == item.ItemCode).ToList();
                            
                            // If itemCode more than 1 recod
                            if(itemData.Count > 1)
                            {
                                // Get Recod Have Max ApplyDate
                                var maxApplydate = itemData.OrderByDescending(x => x.ApplyDate).Take(1).First();
                                listItemMaster.Add(maxApplydate);
                            }
                            else
                            {
                                listItemMaster.Add(itemData.First());
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
                                if (TotalItemMaster > CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = CommonConfiguration.DataCommon.MaxRecol;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageErrorMoreThan100Recol;
                                    result.Status = true;
                                    result.ListItemMaster = ItemMasterByStoreCode.OrderByDescending(x => x.ApplyDate).Take(CommonConfiguration.DataCommon.MaxRecol).ToList();
                                }
                                else if (TotalItemMaster < CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = TotalItemMaster;
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
    }
}
