import { createSlice } from "@reduxjs/toolkit";

export const OldURLReducer = createSlice({
  name: "oldUrl",
  initialState: {
    ListoldUrlItem: [],
  },
  reducers: {
    AddUrl: (state, action) => {
      state.ListoldUrlItem.push(action.payload);
    },
    DeleteURL: (state, action) => {
      state.ListoldUrlItem.splice(0, 1);
    },
  },
});
