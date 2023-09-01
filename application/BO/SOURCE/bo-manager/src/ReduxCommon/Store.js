import { configureStore } from "@reduxjs/toolkit";
import { OldURLReducer } from "../ReduxCommon/ReducerCommon/ReducerURL";
import { AreaReducer } from "../ReduxCommon/ReducerCommon/ReducerArea";
import { StoreReducer } from "../ReduxCommon/ReducerCommon/ReducerStore";
import { ItemMasterReducer } from "../ReduxCommon/ReducerCommon/ReducerItemMaster";

const store = configureStore({
  reducer: {
    oldUrl: OldURLReducer.reducer,
    areaData: AreaReducer.reducer,
    storeData: StoreReducer.reducer,
    itemMasterData: ItemMasterReducer.reducer,
  },
});

export default store;
