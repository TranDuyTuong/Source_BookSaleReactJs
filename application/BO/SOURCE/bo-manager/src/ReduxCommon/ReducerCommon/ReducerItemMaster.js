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
  },
});
