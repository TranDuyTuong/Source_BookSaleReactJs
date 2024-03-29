﻿using CodeFirtMigration.DataFE;
using ConfigurationInterfaces.BoSystem;
using ConfigurationInterfaces.DataCommon;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelConfiguration.M_Bo.AuthorData;
using ModelConfiguration.M_Bo.CategoryData;
using ModelConfiguration.M_Bo.ImageItemMasterData;
using ModelConfiguration.M_Bo.ItemMasterData;
using ModelConfiguration.M_Bo.PublishingCompanysData;
using ModelConfiguration.M_Bo.StoreData;
using ModelConfiguration.M_Common;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly IConfiguration configuration;
        public ItemMasterBO(ContextFE _context, IContactCommon _contactCommon, IConfiguration _configuration)
        {
            this.context = _context;
            this.contactCommon = _contactCommon;
            this.configuration = _configuration;
        }

        /// <summary>
        /// InitializaItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_InitializaDataMaster> InitializaItemMaster(InitializaDataMaters request)
        {
            var result = new M_InitializaDataMaster();
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
                        result.KeySeach = null;
                        result.CompanyCode = request.CompanyCode;
                        result.Status = false;
                        result.MessageError = CommonConfiguration.DataCommon.MessageRoleUserLimit;
                    }
                    else
                    {
                        // Get All Store in DB Store Proceduer
                        var queryStore = await this.context.stores.FromSqlRaw("exec GetAll_Store").ToArrayAsync();
                        // Get All Author in DB Store Proceduer
                        var queryAuthor = await this.context.authors.FromSqlRaw("exec GetAll_Author").ToArrayAsync();
                        // Get All Category in DB Category Store Proceduer
                        var queryCategory = await this.context.categoryItemMasters.FromSqlRaw("exec GetAll_Category").ToArrayAsync();

                        if (queryStore.Any() == true && queryAuthor.Any() == true && queryCategory.Any() == true)
                        {
                            // Store
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

                            // Author
                            List<M_Author> authorList = new List<M_Author>();

                            foreach (var author in queryAuthor)
                            {
                                var authorItem = new M_Author()
                                {
                                    AuthorID = author.AuthorID,
                                    NameAuthor = author.NameAuthor
                                };
                                authorList.Add(authorItem);
                            }

                            // Category
                            List<M_Category> categoryList = new List<M_Category>();

                            foreach (var category in queryCategory)
                            {
                                var categoryItem = new M_Category()
                                {
                                    CategoryItemMasterID = category.CategoryItemMasterID,
                                    Description = category.Description
                                };
                                categoryList.Add(categoryItem);
                            }

                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.KeySeach = null;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = true;
                            result.MessageError = null;
                            result.ListStore = storeList;
                            result.ListAuthor = authorList;
                            result.ListCategory = categoryList;
                        }
                        else
                        {
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
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
                            size = x.itemMaster.size,
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

                        foreach (var item in listResultQuery)
                        {
                            if (state_ItemMasterCode == item.ItemCode)
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

                        if (listItemMaster.Any() == true)
                        {
                            // Count ItemMaster
                            int TotalItemMaster = listItemMaster.Count();
                            // Find ItemMaster
                            // 1) Seach Have CompanyCode, Not ItemCode, Not StoreCodde
                            if (request.CompanyCode != null && (request.KeySeach == null || request.KeySeach == "") && request.StoreCode == null)
                            {
                                // More Than 100 Recol
                                if (TotalItemMaster > CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = CommonConfiguration.DataCommon.MaxRecol;
                                    result.MessageError = CommonConfiguration.DataCommon.MessageErrorMoreThan100Recol;
                                    result.Status = true;
                                    result.ListItemMaster = listItemMaster.OrderByDescending(x => x.ApplyDate).Take(CommonConfiguration.DataCommon.MaxRecol).ToList();
                                }
                                else if (TotalItemMaster < CommonConfiguration.DataCommon.MaxRecol)
                                {
                                    result.TotalItemMaster = TotalItemMaster;
                                    result.MessageError = null;
                                    result.Status = true;
                                    result.ListItemMaster = listItemMaster.OrderByDescending(x => x.ApplyDate).Take(CommonConfiguration.DataCommon.MaxRecol).ToList();
                                }
                            }

                            // 2) Seach Have CompanyCode, Have StoreCode, Not ItemCode
                            if (request.CompanyCode != null && request.StoreCode != null && (request.KeySeach == null || request.KeySeach == ""))
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
                            if (request.CompanyCode != null && request.KeySeach != null && request.StoreCode == null)
                            {
                                // Get ItemMaster By ItemCode
                                var ItemMasterData = listItemMaster.FirstOrDefault(x => x.ItemCode == request.KeySeach);

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

                            // 4) Seach Have Companycode, Have ItemCoe, Have StoreCode
                            if (request.CompanyCode != null && request.KeySeach != null && request.StoreCode != null)
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
                            if (result.Status == true)
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
        public async Task<M_ListItemMaster> ValidationItemMaster(M_ListItemMaster request)
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
                        if (request.KeySeach == null)
                        {
                            // Error null ItemCode
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalItemMaster = 0;
                            result.KeySeach = request.KeySeach;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = false;
                            result.MessageError = CommonConfiguration.DataCommon.MessageNullData;
                        }
                        else
                        {
                            // Validation Lenght ItemCode
                            if (request.KeySeach.Length > CommonConfiguration.DataCommon.MaxLenghtItemCode)
                            {
                                // Error Lenght ItemCode Is Validation
                                result.Token = request.Token;
                                result.UserID = request.UserID;
                                result.RoleID = request.RoleID;
                                result.EventCode = request.EventCode;
                                result.TotalItemMaster = 0;
                                result.KeySeach = request.KeySeach;
                                result.CompanyCode = request.CompanyCode;
                                result.Status = false;
                                result.MessageError = CommonConfiguration.DataCommon.MessageErrorLenghtItemCode;
                            }
                            else
                            {
                                // Check ItemCode Exist in DB
                                var queryItemCode = from item in this.context.itemMasters
                                                    where (
                                                        item.ItemCode == request.KeySeach &&
                                                        item.IsDeleteFlag == false
                                                    )
                                                    select new { item };

                                if (queryItemCode.Any() == false)
                                {
                                    // Not Exit itemcode in DB, Can use this itemcode
                                    result.Token = request.Token;
                                    result.UserID = request.UserID;
                                    result.RoleID = request.RoleID;
                                    result.EventCode = request.EventCode;
                                    result.TotalItemMaster = 0;
                                    result.KeySeach = request.KeySeach;
                                    result.CompanyCode = request.CompanyCode;
                                    result.Status = true;
                                    result.MessageError = null;
                                }
                                else
                                {
                                    // Exit itemcode in DB, Not use this itemcode
                                    result.Token = request.Token;
                                    result.UserID = request.UserID;
                                    result.RoleID = request.RoleID;
                                    result.EventCode = request.EventCode;
                                    result.TotalItemMaster = 0;
                                    result.KeySeach = request.KeySeach;
                                    result.CompanyCode = request.CompanyCode;
                                    result.Status = false;
                                    result.MessageError = "ItemCode Exit in System, Please Try ItemCode Another!";
                                }
                            }
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
        /// ConfirmItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_ListItemMaster> ConfirmItemMaster(M_ListItemMaster request)
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
                        // List Store Validation
                        List<M_Store> listStore = new List<M_Store>();
                        // List Author Validation
                        List<M_Author> listAuthor = new List<M_Author>();
                        // List Category Validation
                        List<M_Category> listCategory = new List<M_Category>();

                        foreach (var item in request.ListItemMaster)
                        {
                            // Store
                            var store = new M_Store()
                            {
                                StoreCode = item.StoreCode,
                            };
                            listStore.Add(store);

                            // Author
                            var author = new M_Author()
                            {
                                AuthorID = item.AuthorID
                            };
                            listAuthor.Add(author);

                            // Category
                            var category = new M_Category()
                            {
                                CategoryItemMasterID = item.CategoryItemMasterID,
                            };
                            listCategory.Add(category);

                        }

                        // Validation Data Select
                        var storeResult = this.contactCommon.ValidationStoreCode(listStore, request.UserID);
                        var authorResult = this.contactCommon.ValidationAuthor(listAuthor, request.UserID);
                        var categoryResult = this.contactCommon.ValidationCategory(listCategory, request.UserID);

                        if (storeResult == false || authorResult == false || categoryResult == false)
                        {
                            // Error Not Find Data Select
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalItemMaster = 0;
                            result.KeySeach = null;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = false;
                            result.MessageError = CommonConfiguration.DataCommon.MessageErrorNotFindDataSelect;
                        }
                        else
                        {
                            // Create ItemMaster 
                            switch (request.OTPControl)
                            {
                                // INSERT
                                case 0:
                                    // Query ItemMaster
                                    var queryItemMaster = from itemMaster in this.context.itemMasters
                                                          where (
                                                          itemMaster.IsDeleteFlag == false
                                                          )
                                                          select itemMaster;
                                    var listItemMaster = queryItemMaster.OrderByDescending(x => x.ApplyDate).Select(x => new M_ItemMaster()
                                    {
                                        ItemCode = x.ItemCode,
                                        CompanyCode = x.CompanyCode,
                                        StoreCode = x.StoreCode,
                                        ApplyDate = x.ApplyDate,
                                    }).ToList();

                                    // Query ItemMasterImage
                                    var queryItemMasterImage = from imageItem in this.context.imageItemMasters
                                                               where (
                                                               imageItem.IsDeleteFlag == false
                                                               )
                                                               select imageItem;
                                    var listItemMasterImage = queryItemMasterImage.Select(x => new ImageItemMaster()
                                    {
                                        ImageItemID = x.ImageItemID,
                                        ItemCode = x.ItemCode,
                                        DateCreate = x.DateCreate,
                                        UserID = x.UserID,
                                        IsDefault = x.IsDefault,
                                        LastUpdateDate = x.LastUpdateDate,
                                        Url = x.Url,
                                        NameImage = x.NameImage,
                                        IsDeleteFlag = x.IsDeleteFlag,
                                    }).ToList();

                                    // Create A List ItemMaster will insert into DB
                                    List<ItemMaster> listItemMasterInsert = new List<ItemMaster>();
                                    // Create A list ImageItemMaster will insert into DB
                                    List<ImageItemMaster> listImageItemMasterInsert = new List<ImageItemMaster>();
                                    // Create A list ImageItemMaster will remove into DB
                                    List<ImageItemMaster> listImageItemMasterRemove = new List<ImageItemMaster>();

                                    foreach (var itemMaster in request.ListItemMaster)
                                    {
                                        var findItemMaster = listItemMaster.FirstOrDefault(x => x.ItemCode == itemMaster.ItemCode
                                                                                             && x.CompanyCode == itemMaster.CompanyCode
                                                                                             && x.StoreCode == itemMaster.StoreCode
                                                                                             && x.ApplyDate == itemMaster.ApplyDate);
                                        if (findItemMaster != null)
                                        {
                                            // Error Exist ItemCode in DB
                                            result.Token = request.Token;
                                            result.UserID = request.UserID;
                                            result.RoleID = request.RoleID;
                                            result.EventCode = request.EventCode;
                                            result.TotalItemMaster = 0;
                                            result.KeySeach = null;
                                            result.CompanyCode = request.CompanyCode;
                                            result.Status = false;
                                            result.MessageError = CommonConfiguration.DataCommon.MessageExistRecolInDB;
                                        }
                                        else
                                        {
                                            // Add ItemMaster In List Insert
                                            var insertItemMaster = new ItemMaster()
                                            {
                                                CompanyCode = itemMaster.CompanyCode,
                                                StoreCode = itemMaster.StoreCode,
                                                ItemCode = itemMaster.ItemCode,
                                                ApplyDate = itemMaster.ApplyDate,
                                                Description = itemMaster.Description,
                                                DescriptionShort = itemMaster.DescriptionShort,
                                                DescriptionLong = itemMaster.DescriptionLong,
                                                PriceOrigin = itemMaster.PriceOrigin,
                                                Quantity = itemMaster.Quantity,
                                                Viewer = itemMaster.Viewer,
                                                Buy = itemMaster.Buy,
                                                CategoryItemMasterID = itemMaster.CategoryItemMasterID,
                                                AuthorID = itemMaster.AuthorID,
                                                DateCreate = itemMaster.DateCreate,
                                                size = itemMaster.size,
                                                IsSale = false,
                                                LastUpdateDate = itemMaster.LastUpdateDate,
                                                Note = itemMaster.Note,
                                                HeadquartersLastUpdateDateTime = itemMaster.HeadquartersLastUpdateDateTime,
                                                IsDeleteFlag = itemMaster.IsDeleteFlag,
                                                UserID = request.UserID,
                                            };
                                            listItemMasterInsert.Add(insertItemMaster);

                                            // Find ItemCode in Table ImageItemMaster
                                            var findImageItemCode = listItemMasterImage.FirstOrDefault(x => x.ItemCode == itemMaster.ItemCode);

                                            if (findImageItemCode != null)
                                            {
                                                // Remove this ItemCode In Table ImageItemMaster
                                                listImageItemMasterRemove.Add(findImageItemCode);
                                            }

                                            // Affter Add ItemMaster Remove Will get ImageItemCode New Insert List Create ItemMaster
                                            var imageItemMasterResult = HandleSplitUrlImage(request.ListItemMaster, itemMaster.ItemCode);

                                            foreach (var item in imageItemMasterResult)
                                            {
                                                var imageItemMasterInsert = new ImageItemMaster()
                                                {
                                                    ImageItemID = item.ImageItemID,
                                                    ItemCode = item.ItemCode,
                                                    DateCreate = item.DateCreate,
                                                    UserID = request.UserID,
                                                    IsDefault = item.IsDefault,
                                                    LastUpdateDate = item.LastUpdateDate,
                                                    Url = item.Url,
                                                    NameImage = null,
                                                    IsDeleteFlag = item.IsDeleteFlag
                                                };
                                                listImageItemMasterInsert.Add(imageItemMasterInsert);
                                            }

                                            result.Status = true;
                                        }
                                    }

                                    if (result.Status != false)
                                    {
                                        // Insert ItemMaster
                                        await this.context.itemMasters.AddRangeAsync(listItemMasterInsert);

                                        // Create Log Insert ItemMaster
                                        List<Log> listLogInsertItemMaster = new List<Log>();
                                        foreach (var itemMaster in listItemMasterInsert)
                                        {
                                            var logInsertItemMaster = new Log()
                                            {
                                                Id = new Guid(),
                                                UserID = request.UserID,
                                                Message = "Insert: ItemMaster Have ItemCode: " + itemMaster.ItemCode,
                                                Status = true,
                                                DateCreate = DateTime.Now,
                                            };
                                            listLogInsertItemMaster.Add(logInsertItemMaster);
                                        }
                                        await this.context.logs.AddRangeAsync(listLogInsertItemMaster);

                                        // Remove ImageItemMaster When Exit ItemCode
                                        this.context.imageItemMasters.RemoveRange(listImageItemMasterRemove);

                                        // Create Log Remove ImageItemMaster
                                        List<Log> listLogRemoveImageItemMaster = new List<Log>();
                                        foreach (var image in listImageItemMasterRemove)
                                        {
                                            var logRemoveImage = new Log()
                                            {
                                                Id = new Guid(),
                                                UserID = request.UserID,
                                                Message = "Remove: Image ItemMaster Have ItemCode: " + image.ItemCode,
                                                Status = true,
                                                DateCreate = DateTime.Now,
                                            };
                                            listLogRemoveImageItemMaster.Add(logRemoveImage);
                                        }
                                        await this.context.logs.AddRangeAsync(listLogRemoveImageItemMaster);

                                        // Insert New ImageItemMaster
                                        await this.context.imageItemMasters.AddRangeAsync(listImageItemMasterInsert);

                                        // Create Log Insert ImageItemMaster
                                        List<Log> listLogInsertImageItemMaster = new List<Log>();
                                        foreach (var image in listImageItemMasterInsert)
                                        {
                                            var logInsertImage = new Log()
                                            {
                                                Id = new Guid(),
                                                UserID = request.UserID,
                                                Message = "Insert: Image ItemMaster Have ItemCode: " + image.ItemCode,
                                                Status = true,
                                                DateCreate = DateTime.Now,
                                            };
                                            listLogInsertImageItemMaster.Add(logInsertImage);
                                        }
                                        // Insert New Log Create ImageItemMaster
                                        await this.context.logs.AddRangeAsync(listLogInsertImageItemMaster);

                                        // Save In DB
                                        await this.context.SaveChangesAsync();

                                        // Data result
                                        result.Token = request.Token;
                                        result.UserID = request.UserID;
                                        result.RoleID = request.RoleID;
                                        result.EventCode = request.EventCode;
                                        result.TotalItemMaster = 0;
                                        result.KeySeach = null;
                                        result.CompanyCode = request.CompanyCode;
                                        result.Status = true;
                                        result.MessageError = null;
                                    }
                                    break;

                                // UPDATE BASE
                                case 1:
                                    var resultUPDATE = this.UpdateBaseItemMater(request.ListItemMaster);

                                    if (resultUPDATE.Status == true)
                                    {
                                        // SUCCESS
                                        result.Token = request.Token;
                                        result.UserID = request.UserID;
                                        result.RoleID = request.RoleID;
                                        result.EventCode = request.EventCode;
                                        result.TotalItemMaster = 0;
                                        result.KeySeach = null;
                                        result.CompanyCode = request.CompanyCode;
                                        result.Status = true;
                                        result.MessageError = null;
                                    }
                                    else
                                    {
                                        // ERROR
                                        result.Token = request.Token;
                                        result.UserID = request.UserID;
                                        result.RoleID = request.RoleID;
                                        result.EventCode = request.EventCode;
                                        result.TotalItemMaster = 0;
                                        result.KeySeach = null;
                                        result.CompanyCode = request.CompanyCode;
                                        result.Status = false;
                                        result.MessageError = resultUPDATE.MessageError;
                                    }
                                    break;

                                // CHANGE PRICE 
                                case 3:
                                    var resultCHANGEPRICE = this.ChangePriceItemMaster(request.ListItemMaster);

                                    if (resultCHANGEPRICE.Status == true)
                                    {
                                        // SUCCESS
                                        result.Token = request.Token;
                                        result.UserID = request.UserID;
                                        result.RoleID = request.RoleID;
                                        result.EventCode = request.EventCode;
                                        result.TotalItemMaster = 0;
                                        result.KeySeach = null;
                                        result.CompanyCode = request.CompanyCode;
                                        result.Status = true;
                                        result.MessageError = null;
                                    }
                                    else
                                    {
                                        // ERROR
                                        result.Token = request.Token;
                                        result.UserID = request.UserID;
                                        result.RoleID = request.RoleID;
                                        result.EventCode = request.EventCode;
                                        result.TotalItemMaster = 0;
                                        result.KeySeach = null;
                                        result.CompanyCode = request.CompanyCode;
                                        result.Status = false;
                                        result.MessageError = resultCHANGEPRICE.MessageError;
                                    }
                                    break;
                                // DELETE
                                default:
                                    break;
                            }

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
        /// GetAllItemMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<M_ListItemMaster> GetAllItemMaster(InitializaDataMaters request)
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
                        List<M_ItemMaster> listItemMaster = new List<M_ItemMaster>();
                        // Get ItemMaster by store code in DB
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = this.configuration["ConnectionStrings:TXTCloud"];
                        con.Open();
                        using (var sqlcmd = con.CreateCommand())
                        {
                            sqlcmd.CommandText = "GetAll_ItemMaster";
                            sqlcmd.Parameters.AddWithValue("@StoreCode", request.StoreCode == null ? null : request.StoreCode);
                            sqlcmd.Parameters.AddWithValue("@CompanyCode", request.CompanyCode);
                            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                            var readers = sqlcmd.ExecuteReader();
                            while (readers.Read())
                            {
                                var itemMasterData = new M_ItemMaster()
                                {
                                    ItemCode = readers["ItemCode"].ToString(),
                                    Description = readers["Description"].ToString()
                                };
                                listItemMaster.Add(itemMasterData);
                            }
                        }
                        con.Close();

                        if (listItemMaster.Count() < CommonConfiguration.DataCommon.MaxRecol)
                        {
                            result.MessageError = "Find: " + listItemMaster.Count + " recol";
                        }
                        else
                        {
                            result.TotalItemMaster = 0;
                            result.MessageError = "More Than 100 recol in system, should show 100 recol fist!";
                        }
                        // Set Data result
                        result.Token = request.Token;
                        result.UserID = request.UserID;
                        result.RoleID = request.RoleID;
                        result.EventCode = request.EventCode;
                        result.KeySeach = null;
                        result.CompanyCode = request.CompanyCode;
                        result.Status = true;
                        result.ListItemMaster = listItemMaster;
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
        /// GetItemMasterById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<M_ListItemMaster> GetItemMasterById(M_ListItemMaster request)
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
                        List<M_ItemMaster> listItemMaster = new List<M_ItemMaster>();
                        // Get ItemMaster By ItemCode By StoredProcedure
                        // Get Connectionstring
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = this.configuration["ConnectionStrings:TXTCloud"];
                        con.Open();
                        using (var sqlcmd = con.CreateCommand())
                        {
                            sqlcmd.CommandText = "GetItemMaster_ByID";
                            sqlcmd.Parameters.AddWithValue("@itemCode", request.KeySeach);
                            sqlcmd.Parameters.AddWithValue("@storeCode", request.StoreCode);
                            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                            var reader = sqlcmd.ExecuteReader();
                            while (reader.Read())
                            {
                                // Image ItemMaster Data
                                var urlDefaultImage = new M_GetUrlImageBo()
                                {
                                    IsDefault = true,
                                    UrlImageDefault = reader["ImageDefault"].ToString(),
                                    UrlImage = null
                                };

                                // ItemMaster Data
                                var itemMasterData = new M_ItemMaster()
                                {
                                    CompanyCode = request.CompanyCode,
                                    Id = Guid.NewGuid(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    DescriptionLong = reader["DescriptionLong"].ToString(),
                                    DescriptionShort = reader["DescriptionShort"].ToString(),
                                    StoreCode = reader["StoreCode"].ToString(),
                                    CategoryItemMasterID = reader["CategoryItemMasterID"].ToString(),
                                    AuthorID = reader["AuthorID"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                    size = reader["size"].ToString(),
                                    Note = reader["Note"].ToString(),
                                    ApplyDate = DateTime.Parse(reader["ApplyDate"].ToString()),
                                    ImageItemMaster = urlDefaultImage
                                };

                                // Add ItemMaster Result 
                                listItemMaster.Add(itemMasterData);
                            }
                        }
                        con.Close();

                        // Result ItemMaster Data
                        if (listItemMaster.Any() == true)
                        {
                            result.CompanyCode = request.CompanyCode;
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalItemMaster = listItemMaster.Count();
                            result.KeySeach = request.KeySeach;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = true;
                            result.MessageError = null;
                            result.ListItemMaster = listItemMaster;
                        }
                        else
                        {
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalItemMaster = 0;
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
        /// HandleSplitUrlImage
        /// </summary>
        /// <param name="listItemMaster"></param>
        /// <returns></returns>
        private List<M_ImageItemMaster> HandleSplitUrlImage(List<M_ItemMaster> listItemMaster, string itemCode)
        {
            List<M_ImageItemMaster> listImageAffterHandle = new List<M_ImageItemMaster>();

            foreach (var item in listItemMaster)
            {
                if (item.ItemCode == itemCode)
                {
                    // Split Url 
                    string[] splitUrl = item.ImageItemMaster.UrlImage.Split("\n");

                    foreach (var urlSplit in splitUrl)
                    {
                        // url child
                        var url = new M_ImageItemMaster()
                        {
                            ImageItemID = new Guid(),
                            ItemCode = item.ItemCode,
                            DateCreate = DateTime.Now,
                            UserID = item.UserID,
                            IsDefault = false,
                            LastUpdateDate = null,
                            Url = urlSplit,
                            NameImage = null,
                            IsDeleteFlag = false
                        };
                        listImageAffterHandle.Add(url);
                    }

                    // Handle Url Default
                    var urlDefault = new M_ImageItemMaster()
                    {
                        ImageItemID = new Guid(),
                        ItemCode = item.ItemCode,
                        DateCreate = DateTime.Now,
                        UserID = item.UserID,
                        IsDefault = true,
                        LastUpdateDate = null,
                        Url = item.ImageItemMaster.UrlImageDefault,
                        NameImage = null,
                        IsDeleteFlag = false
                    };
                    listImageAffterHandle.Add(urlDefault);
                }
            }

            return listImageAffterHandle;
        }

        /// <summary>
        /// UpdateBaseItemMater
        /// </summary>
        /// <param name="ItemMasterParam"></param>
        /// <returns></returns>
        private ResultStoreProceducer UpdateBaseItemMater(List<M_ItemMaster> ItemMasterParam)
        {
            var result = new ResultStoreProceducer();
            try
            {
                // Update ItemMaster store proceducer
                SqlConnection con = new SqlConnection();
                con.ConnectionString = this.configuration["ConnectionStrings:TXTCloud"];
                con.Open();
                foreach (var item in ItemMasterParam)
                {
                    using (var sqlcmm = con.CreateCommand())
                    {
                        sqlcmm.CommandText = "UpdateBase_ItemMaster";
                        sqlcmm.Parameters.AddWithValue("@StoreCode", item.StoreCode);
                        sqlcmm.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                        sqlcmm.Parameters.AddWithValue("@ApplyDate", item.ApplyDate);
                        sqlcmm.Parameters.AddWithValue("@Description", item.Description);
                        sqlcmm.Parameters.AddWithValue("@DescriptionShort", item.DescriptionShort);
                        sqlcmm.Parameters.AddWithValue("@DescriptionLong", item.DescriptionLong);
                        sqlcmm.Parameters.AddWithValue("@Quantity", item.Quantity);
                        sqlcmm.Parameters.AddWithValue("@CategoryItemMasterID", item.CategoryItemMasterID);
                        sqlcmm.Parameters.AddWithValue("@AuthorID", item.AuthorID);
                        sqlcmm.Parameters.AddWithValue("@size", item.size);
                        sqlcmm.Parameters.AddWithValue("@Note", item.Note);
                        sqlcmm.Parameters.AddWithValue("@UserID", item.UserID);
                        sqlcmm.CommandType = System.Data.CommandType.StoredProcedure;
                        var reader = sqlcmm.ExecuteNonQuery();

                        if (reader == -1)
                        {
                            // Update Fail
                            result.Status = false;
                            result.MessageError = "Update ItemMaster Fail, Please Try Again!";
                        }
                        else
                        {
                            // Update Success
                            result.Status = true;
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.MessageError = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// ChangePriceItemMaster
        /// </summary>
        /// <param name="ItemMasterParam"></param>
        /// <returns></returns>
        private ResultStoreProceducer ChangePriceItemMaster(List<M_ItemMaster> ItemMasterParam)
        {
            var result = new ResultStoreProceducer();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.configuration["ConnectionStrings:TXTCloud"];
            con.Open();
            foreach (var item in ItemMasterParam)
            {
                // Check Discount Item
                // QuantityDiscount
                if(item.QuantityDiscountID == null || item.QuantityDiscountID == "")
                {
                    item.QuantityDiscountID = null;
                }

                // PairDiscount
                if (item.PairDiscountID == null || item.PairDiscountID == "")
                {
                    item.PairDiscountID = null;
                }

                // SpecialDiscount
                if (item.SpecialDiscountID == null || item.SpecialDiscountID == "")
                {
                    item.SpecialDiscountID = null;
                }

                // TaxGroupCode
                if(item.TaxGroupCodeID == null || item.TaxGroupCodeID == "")
                {
                    item.TaxGroupCodeID = null;
                }

                using (var sqlcmm = con.CreateCommand())
                {
                    sqlcmm.CommandText = "ChangePrice_ItemMaster";
                    sqlcmm.Parameters.AddWithValue("CompanyCode", item.CompanyCode);
                    sqlcmm.Parameters.AddWithValue("StoreCode", item.StoreCode);
                    sqlcmm.Parameters.AddWithValue("ItemCode", item.ItemCode);
                    sqlcmm.Parameters.AddWithValue("Applydate", item.ApplyDate);
                    sqlcmm.Parameters.AddWithValue("Descritpion", item.Description);
                    sqlcmm.Parameters.AddWithValue("DescriptionShort", item.DescriptionShort);
                    sqlcmm.Parameters.AddWithValue("DescriptionLong", item.DescriptionLong);
                    sqlcmm.Parameters.AddWithValue("PriceOrigin", item.PriceOrigin);
                    sqlcmm.Parameters.AddWithValue("PercentDiscount", item.PercentDiscount);
                    sqlcmm.Parameters.AddWithValue("PriceSale", item.priceSale);
                    sqlcmm.Parameters.AddWithValue("QuantityDiscountID", item.QuantityDiscountID);
                    sqlcmm.Parameters.AddWithValue("PairDiscountID", item.PairDiscountID);
                    sqlcmm.Parameters.AddWithValue("SpecialDiscountID", item.SpecialDiscountID);
                    sqlcmm.Parameters.AddWithValue("Quantity", item.Quantity);
                    sqlcmm.Parameters.AddWithValue("Viewer", item.Viewer);
                    sqlcmm.Parameters.AddWithValue("Buy", item.Buy);
                    sqlcmm.Parameters.AddWithValue("CategoryItemMasterID", item.CategoryItemMasterID);
                    sqlcmm.Parameters.AddWithValue("AuthorID", item.AuthorID);
                    sqlcmm.Parameters.AddWithValue("DateCreate", DateTime.Now);
                    sqlcmm.Parameters.AddWithValue("size", item.size);
                    sqlcmm.Parameters.AddWithValue("IsSale", true);
                    sqlcmm.Parameters.AddWithValue("Note", item.Note);
                    sqlcmm.Parameters.AddWithValue("IsDeleteFlag", false);
                    sqlcmm.Parameters.AddWithValue("UserID", item.UserID);
                    sqlcmm.Parameters.AddWithValue("TaxGroupCodeID", item.TaxGroupCodeID);
                    sqlcmm.Parameters.AddWithValue("LastUpdateDate", DateTime.Now);
                    sqlcmm.Parameters.AddWithValue("TypeOf", item.TypeOf);
                    sqlcmm.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = sqlcmm.ExecuteNonQuery();

                    if (reader == -1)
                    {
                        result.Status = false;
                        result.MessageError = "Change Price Fail: " + item.ItemCode + " , Please check again";
                        con.Close();
                        // Update Fail
                        return result;
                    }
                }
            }
            // Update Success
            result.Status = true;
            con.Close();
            return result;
        }


        /// <summary>
        /// GetItemMasterUpdatePriceById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<M_ListItemMaster> GetItemMasterUpdatePriceById(M_ListItemMaster request)
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
                        List<M_ItemMaster> listItemMaster = new List<M_ItemMaster>();
                        // Get ItemMaster update price By ItemCode By StoredProcedure
                        // Get Connectionstring
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = this.configuration["ConnectionStrings:TXTCloud"];
                        con.Open();
                        using (var sqlcmd = con.CreateCommand())
                        {
                            sqlcmd.CommandText = "GetItemMasterUpdatePrice_ByID";
                            sqlcmd.Parameters.AddWithValue("@itemCode", request.KeySeach);
                            sqlcmd.Parameters.AddWithValue("@storeCode", request.StoreCode);
                            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                            var reader = sqlcmd.ExecuteReader();
                            while (reader.Read())
                            {
                                // ItemMaster Data
                                var itemMasterData = new M_ItemMaster()
                                {
                                    CompanyCode = request.CompanyCode,
                                    Id = Guid.NewGuid(),
                                    ItemCode = reader["ItemCode"].ToString(),
                                    StoreCode = reader["StoreCode"].ToString(),
                                    AuthorID = reader["AuthorID"].ToString(),
                                    CategoryItemMasterID = reader["CategoryItemMasterID"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ApplyDate = DateTime.Parse(reader["ApplyDate"].ToString()),
                                    PriceOrigin = Convert.ToDecimal(reader["PriceOrigin"].ToString()),
                                    priceSale = Convert.ToDecimal(reader["PriceSale"].ToString()),
                                    PercentDiscount = Convert.ToInt32(reader["PercentDiscount"].ToString()),
                                    DescriptionShort = reader["DescriptionShort"].ToString(),
                                    DescriptionLong = reader["DescriptionLong"].ToString(),
                                    QuantityDiscountID = reader["QuantityDiscountID"].ToString(),
                                    PairDiscountID = reader["PairDiscountID"].ToString(),
                                    SpecialDiscountID = reader["SpecialDiscountID"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"].ToString()),
                                    Viewer = Convert.ToInt32(reader["Viewer"].ToString()),
                                    Buy = Convert.ToInt32(reader["Buy"].ToString()),
                                    size = reader["size"].ToString(),
                                    Note = reader["Note"].ToString(),
                                    HeadquartersLastUpdateDateTime = DateTime.Parse(reader["HeadquartersLastUpdateDateTime"].ToString()),
                                    UserID = reader["UserID"].ToString(),
                                    TaxGroupCodeID = reader["TaxGroupCodeID"].ToString()
                                };

                                // Add ItemMaster Result 
                                listItemMaster.Add(itemMasterData);
                            }
                        }
                        con.Close();

                        // Result ItemMaster Data
                        if (listItemMaster.Any() == true)
                        {
                            result.CompanyCode = request.CompanyCode;
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalItemMaster = listItemMaster.Count();
                            result.KeySeach = request.KeySeach;
                            result.CompanyCode = request.CompanyCode;
                            result.Status = true;
                            result.MessageError = null;
                            result.ListItemMaster = listItemMaster;
                        }
                        else
                        {
                            result.Token = request.Token;
                            result.UserID = request.UserID;
                            result.RoleID = request.RoleID;
                            result.EventCode = request.EventCode;
                            result.TotalItemMaster = 0;
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

    public class ResultStoreProceducer
    {
        /// <summary>
        /// Status
        /// </summary>
        public bool Status
        {
            get;
            set;
        }

        /// <summary>
        /// MessageError
        /// </summary>
        public string MessageError
        {
            get;
            set;
        }
    }
}
