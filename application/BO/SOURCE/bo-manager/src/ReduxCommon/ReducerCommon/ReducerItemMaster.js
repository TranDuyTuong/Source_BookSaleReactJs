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
  },
});
