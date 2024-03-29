import { createSlice } from "@reduxjs/toolkit";

export const StoreReducer = createSlice({
  name: "storeRedux",
  initialState: {
    ListStore: [],
  },
  reducers: {
    AddStore: (state, action) => {
      const checkStoreCode = state.ListStore.find(
        (item) => item.StoreCode === action.payload.StoreCode
      );
      if (checkStoreCode === undefined) {
        state.ListStore.unshift(action.payload);
      }
    },
    SeachStore: (state, action) => {
      state.ListStore = action.payload;
    },
    DeleteStore: (state, action) => {
      const findStore = state.ListStore.find(
        (item) => item.StoreCode === action.payload.StoreCode
      );
      if (findStore !== undefined) {
        findStore.TypeOf = action.payload.TypeOf;
        findStore.OldType = action.payload.OldType;
      }
    },
    UpdateStore: (state, action) => {
      const findStore = state.ListStore.find(
        (item) => item.StoreCode === action.payload.StoreCode
      );
      if (findStore !== undefined) {
        findStore.Description = action.payload.Description;
        findStore.TypeOf = action.payload.TypeOf;
        findStore.Address = action.payload.Address;
      }
    },
    RevertStore: (state, action) => {
      const findStore = state.ListStore.find(
        (item) => item.StoreCode === action.payload.StoreCode
      );
      if (findStore !== undefined) {
        findStore.TypeOf = findStore.OldType;
        findStore.OldType = null;
      }
    },
  },
});
