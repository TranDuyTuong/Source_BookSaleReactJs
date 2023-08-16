import { configureStore } from "@reduxjs/toolkit";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { AreaReducer } from "../ReduxCommon/ReducerCommon/ReducerArea";

const store = configureStore({
  reducer: {
    oldUrl: OldURLReducer.reducer,
    areaData: AreaReducer.reducer,
  },
});

export default store;
