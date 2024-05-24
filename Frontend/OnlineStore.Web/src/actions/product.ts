import {
  LOAD_ALL_PRODUCT,
  LOAD_ALL_PRODUCT_SUCCESS,
  LOAD_ALL_PRODUCT_FAILED,
} from "../types/productType";

export const getAllProduct = (pageSize: string, pageNumber: string) => {
  return {
    type: LOAD_ALL_PRODUCT,
    pageSize,
    pageNumber,
  };
};

export const getAllProductSuccess = (response: object[]) => {
  return {
    type: LOAD_ALL_PRODUCT_SUCCESS,
    response,
  };
};

export const getAllProductFailed = (error: Error) => {
  return {
    type: LOAD_ALL_PRODUCT_FAILED,
    error,
  };
};
