import { configureStore } from "@reduxjs/toolkit";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";

const store = configureStore({
  reducer: {
    oldUrl: OldURLReducer.reducer,
  },
});

export default store;
