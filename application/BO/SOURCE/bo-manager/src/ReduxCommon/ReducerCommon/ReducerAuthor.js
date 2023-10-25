import { createSlice } from "@reduxjs/toolkit";

export const AuthorReducer = createSlice({
  name: "authorRedux",
  initialState: {
    ListAuthor: [],
  },
  reducers: {
    SeachAuthor: (state, action) => {
      state.ListAuthor = action.payload;
    },
  },
});
