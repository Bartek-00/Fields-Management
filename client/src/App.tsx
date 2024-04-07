import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ChakraProvider } from "@chakra-ui/react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import HomePage from "./Pages/HomePage";
import NotFoundPage from "./Pages/NotFoundPage";
import LoginPage from "./Pages/LoginPage";
import OperationsPage from "./Pages/OperationsPage";
import WorkersPage from "./Pages/WorkersPage";
import StatisticsPage from "./Pages/StatisticsPage";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false,
    },
  },
});

const router = createBrowserRouter([
  {
    path: "/",
    element: <LoginPage />,
    errorElement: <NotFoundPage />,
  },
  {
    path: "/home",
    element: <HomePage />,
    // children: [
    //   {
    //     path: '/profiles/:profileId',
    //     element: <HomePage />,
    //   },
    // ],
  },
  {
    path: "/Operations",
    element: <OperationsPage />,
    errorElement: <NotFoundPage />,
  },
  {
    path: "/Fields",
    element: <OperationsPage />,
    errorElement: <NotFoundPage />,
  },
  {
    path: "/Workers",
    element: <WorkersPage />,
    errorElement: <NotFoundPage />,
  },
  {
    path: "/Statistics",
    element: <StatisticsPage />,
    errorElement: <NotFoundPage />,
  },
]);

root.render(
  <React.StrictMode>
    <QueryClientProvider client={queryClient}>
      <ChakraProvider>
        <RouterProvider router={router} />
      </ChakraProvider>
    </QueryClientProvider>
  </React.StrictMode>
);
