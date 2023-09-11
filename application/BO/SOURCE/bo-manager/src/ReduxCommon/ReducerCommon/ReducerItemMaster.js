import { createSlice } from "@reduxjs/toolkit";

export const ItemMasterReducer = createSlice({
  name: "itemMasterRedux",
  initialState: {
    ListItemMaster: [],
  },
  reducers: {
    SeachItemMaster: (state, action) => {
      state.ListItemMaster = action.payload;
    },
    AddItemMaster: (state, action) => {
      const checkItemCode = state.ListItemMaster.find(
        (item) => item.ItemCode === action.payload.ItemCode
      );
      if (checkItemCode === undefined) {
        state.ListItemMaster.unshift(action.payload);
      }
    },
    UpdateItemMaster: (state, action) => {
      const findItemMaster = state.ListItemMaster.find(
        (item) => item.ItemCode === action.payload.ItemCode
      );
      if (checkItemCode !== undefined) {
        findItemMaster.CompanyCode = action.payload.CompanyCode;
        findItemMaster.StoreCode = action.payload.StoreCode;
        findItemMaster.ItemCode = action.payload.ItemCode;
        findItemMaster.ApplyDate = action.payload.ApplyDate;
        findItemMaster.Description = action.payload.Description;
        findItemMaster.DescriptionShort = action.payload.DescriptionShort;
        findItemMaster.DescriptionLong = action.payload.DescriptionLong;
        findItemMaster.PriceOrigin = action.payload.PriceOrigin;
        findItemMaster.PercentDiscount = action.payload.PercentDiscount;
        findItemMaster.priceSale = action.payload.priceSale;
        findItemMaster.QuantityDiscountID = action.payload.QuantityDiscountID;
        findItemMaster.PairDiscountID = action.payload.PairDiscountID;
        findItemMaster.SpecialDiscountID = action.payload.SpecialDiscountID;
        findItemMaster.Quantity = action.payload.Quantity;
        findItemMaster.Viewer = action.payload.Viewer;
        findItemMaster.Buy = action.payload.Buy;
        findItemMaster.CategoryItemMasterID =
          action.payload.CategoryItemMasterID;
        findItemMaster.AuthorID = action.payload.AuthorID;
        findItemMaster.DateCreate = action.payload.DateCreate;
        findItemMaster.IssuingCompanyID = action.payload.IssuingCompanyID;
        findItemMaster.PublicationDate = action.payload.PublicationDate;
        findItemMaster.size = action.payload.size;
        findItemMaster.PageNumber = action.payload.PageNumber;
        findItemMaster.PublishingCompanyID = action.payload.PublishingCompanyID;
        findItemMaster.IsSale = action.payload.IsSale;
        findItemMaster.LastUpdateDate = action.payload.LastUpdateDate;
        findItemMaster.Note = action.payload.Note;
        findItemMaster.HeadquartersLastUpdateDateTime =
          action.payload.HeadquartersLastUpdateDateTime;
        findItemMaster.IsDeleteFlag = action.payload.IsDeleteFlag;
        findItemMaster.UserID = action.payload.UserID;
        findItemMaster.TaxGroupCodeID = action.payload.TaxGroupCodeID;
        findItemMaster.TypeOf = action.payload.TypeOf;
        findItemMaster.OldType = action.payload.OldType;
        findItemMaster.UrlImage = action.payload.UrlImage;
      }
    },
    DeleteItemMaster: (state, action) => {
      const findItemMaster = state.ListItemMaster.find(
        (item) => item.ItemCode === action.payload.ItemCode
      );
      if (findItemMaster !== undefined) {
        findItemMaster.TypeOf = action.payload.TypeOf;
        findItemMaster.OldType = action.payload.OldType;
      }
    },
    RevertItemMaster: (state, action) => {
      const findItemMaster = state.ListItemMaster.find(
        (item) => item.ItemCode === action.payload.ItemCode
      );
      if (findItemMaster !== undefined) {
        findItemMaster.TypeOf = action.payload.TypeOf;
        findItemMaster.OldType = action.payload.OldType;
      }
    },
  },
});
