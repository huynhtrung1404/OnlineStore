import ProductState, {
  LOAD_ALL_PRODUCT,
  LOAD_ALL_PRODUCT_SUCCESS,
  LOAD_ALL_PRODUCT_FAILED,
} from "../types/productType";

const initialState: ProductState = {
  loading: false,
  products: [],
  error: null,
  pageSize: "10",
  pageNumber: "1",
};

export default (
  state = initialState,
  action: {
    type: string;
    pageSize: string;
    pageNumner: string;
    response: Array<object>;
    error: Error;
  }
) => {
  switch (action.type) {
    case LOAD_ALL_PRODUCT:
      state.loading = true;
      state.error = null;
      state.pageSize = action.pageSize;
      state.pageNumber = action.pageNumner;
      break;
    case LOAD_ALL_PRODUCT_SUCCESS:
      state.loading = false;
      state.products = action.response;
      break;
    case LOAD_ALL_PRODUCT_FAILED:
      state.loading = false;
      state.error = action.error.message;
      break;
  }
};
