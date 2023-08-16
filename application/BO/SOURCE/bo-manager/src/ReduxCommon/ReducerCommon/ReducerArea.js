import { createSlice } from "@reduxjs/toolkit";

export const AreaReducer = createSlice({
  name: "areaRedux",
  initialState: {
    ListArea: [],
  },
  reducers: {
    AddArea: (state, action) => {
      state.ListArea.push(action.payload);
    },
    SeachArea: (state, action) => {
      state.ListArea = action.payload;
    },
    DeleteArea: (state, action) => {},
    UpdateArea: (state, action) => {},
  },
});
