import { createSlice } from "@reduxjs/toolkit";

export const AreaReducer = createSlice({
  name: "areaRedux",
  initialState: {
    ListArea: [],
  },
  reducers: {
    AddArea: (state, action) => {
      const checkAreaCode = state.ListArea.find(
        (item) => item.AreaCode === action.payload.AreaCode
      );
      if (checkAreaCode === undefined) {
        state.ListArea.unshift(action.payload);
      }
    },
    SeachArea: (state, action) => {
      state.ListArea = action.payload;
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
