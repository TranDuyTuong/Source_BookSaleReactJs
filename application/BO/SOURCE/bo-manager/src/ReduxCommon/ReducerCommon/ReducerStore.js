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
    DeleteArea: (state, action) => {
      const findArea = state.ListArea.find(
        (item) => item.AreaCode === action.payload.AreaCode
      );
      if (findArea !== undefined) {
        findArea.TypeOf = action.payload.TypeOf;
        findArea.OldType = action.payload.OldType;
      }
    },
    UpdateArea: (state, action) => {
      const findArea = state.ListArea.find(
        (item) => item.AreaCode === action.payload.AreaCode
      );
      if (findArea !== undefined) {
        findArea.Description = action.payload.Description;
        findArea.TypeOf = action.payload.TypeOf;
      }
    },
    RevertArea: (state, action) => {
      const findArea = state.ListArea.find(
        (item) => item.AreaCode === action.payload.AreaCode
      );
      if (findArea !== undefined) {
        findArea.TypeOf = findArea.OldType;
        findArea.OldType = null;
      }
    },
  },
});
