const setName = (name: string) => `Manage/Product/${name}`;
export const LOAD_ALL_PRODUCT = setName("LOAD_ALL_PRODUCT");
export const LOAD_ALL_PRODUCT_SUCCESS = setName("LOAD_ALL_PRODUCT_SUCCESS");
export const LOAD_ALL_PRODUCT_FAILED = setName("LOAD_ALL_PRODUCT_FAILED");
export const LOAD_PRODUCT_BY_ID = setName("LOAD_PRODUCT_BY_ID");
export const ADD_NEW_PRODUCT = setName("ADD_NEW_PRODUCT");
export const UPDATE_PRODUCT = setName("UPDATE_PRODUCT");
export const DELETE_PRODUCT = setName("DELETE_PRODUCT");

export default interface ProductState {
  loading: boolean;
  products: Array<object>;
  error: string | null;
  pageSize: string;
  pageNumber: string;
}
