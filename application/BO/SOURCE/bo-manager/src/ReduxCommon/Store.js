import { configureStore } from "@reduxjs/toolkit";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { AreaReducer } from "../ReduxCommon/ReducerCommon/ReducerArea";
import { StoreReducer } from "../ReduxCommon/ReducerCommon/ReducerStore";

const store = configureStore({
  reducer: {
    oldUrl: OldURLReducer.reducer,
    areaData: AreaReducer.reducer,
    storeData: StoreReducer.reducer,
  },
});

export default store;
