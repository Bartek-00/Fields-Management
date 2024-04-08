"use client";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import LoginComponent from "./../Components/LoginComponent";

export default function LoginPage() {
  const queryClient = new QueryClient({
    defaultOptions: {
      queries: {
        refetchOnWindowFocus: false,
      },
    },
  });

  return (
    <div className="backgroundDiv">
      <div className="darkDiv">
        <QueryClientProvider client={queryClient}>
          <LoginComponent />
        </QueryClientProvider>
      </div>
    </div>
  );
}
