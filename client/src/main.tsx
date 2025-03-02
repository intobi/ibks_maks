import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "bootstrap/dist/css/bootstrap.css";
import App from "./App.tsx";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import UpdateTicket from "./components/ticket/UpdateTicket.tsx";

const router = createBrowserRouter([
  { path: "/", element: <App /> },
  { path: "/ticket/:id", element: <UpdateTicket /> },
]);

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
);
