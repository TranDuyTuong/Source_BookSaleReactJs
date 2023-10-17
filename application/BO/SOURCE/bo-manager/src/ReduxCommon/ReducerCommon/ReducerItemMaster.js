import { createSlice } from "@reduxjs/toolkit";
import { Update, Create } from "../../Contants/DataContant";

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
      if (findItemMaster !== undefined) {
        findItemMaster.CompanyCode = action.payload.CompanyCode;
        findItemMaster.StoreCode = action.payload.StoreCode;
        findItemMaster.ItemCode = action.payload.ItemCode;
        findItemMaster.ApplyDate = action.payload.ApplyDate;
        findItemMaster.Description = action.payload.Description;
        findItemMaster.DescriptionShort = action.payload.DescriptionShort;
        findItemMaster.DescriptionLong = action.payload.DescriptionLong;
        findItemMaster.PriceOrigin = action.payload.PriceOrigin;
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
        findItemMaster.size = action.payload.size;
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
    UpdateItemMasterShort: (state, action) => {
      const findItemMaster = state.ListItemMaster.find(
        (item) =>
          item.ItemCode === action.payload.ItemCode &&
          item.ApplyDate === action.payload.Applydate
      );

      // Not Null
      if (findItemMaster !== undefined) {
        findItemMaster.Description = action.payload.Description;
        findItemMaster.DescriptionShort = action.payload.DescriptionShort;
        findItemMaster.DescriptionLong = action.payload.DescriptionLong;
        findItemMaster.CategoryItemMasterID =
          action.payload.CategoryItemMasterID;
        findItemMaster.AuthorID = action.payload.AuthorID;
        findItemMaster.size = action.payload.size;
        findItemMaster.PublishingCompanyID = action.payload.PublishingCompanyID;
        findItemMaster.Note = action.payload.Note;
        findItemMaster.TypeOf = action.payload.TypeOf;
        findItemMaster.Quantity = action.payload.Quantity;
        findItemMaster.StoreCode = action.payload.StoreCode;
      }
    },
    UpdatePriceChangeItemMaster: (state, action) => {
      const findItemMaster = state.ListItemMaster.find(
        (item) =>
          item.ItemCode === action.payload.itemCode &&
          item.ApplyDate === action.payload.applydate &&
          item.StoreCode === action.payload.storecode
      );

      if (findItemMaster === undefined) {
        const CreateItemMaster = {
          Id: action.payload.id,
          StoreCode: action.payload.storecode,
          ItemCode: action.payload.itemCode,
          ApplyDate: action.payload.applydate,
          Description: action.payload.description,
          PriceOrigin: action.payload.priceOrigin,
          priceSale: action.payload.priceSale,
          PercentDiscount: action.payload.percentDiscount,
          TypeOf: Create,
        };
        state.ListItemMaster.unshift(CreateItemMaster);
      } else {
        findItemMaster.ApplyDate = action.payload.applydate;
        findItemMaster.PriceOrigin = action.payload.priceOrigin;
        findItemMaster.priceSale = action.payload.priceSale;
        findItemMaster.PercentDiscount = action.payload.percentDiscount;
        findItemMaster.TypeOf = Update;
      }
    },
  },
});
