import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import { Provider } from "react-redux";
import store from "./configurations/store.ts";
import "primereact/resources/themes/saga-blue/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  </React.StrictMode>
);
