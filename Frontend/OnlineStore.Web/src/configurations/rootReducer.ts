import { combineReducers } from "@reduxjs/toolkit";

const rootReducer = (dynamicReducer?: object) =>
  combineReducers({ ...dynamicReducer });

export default rootReducer;
