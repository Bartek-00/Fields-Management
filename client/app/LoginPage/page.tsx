"use client";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import LoginComponent from "./../Components/LoginComponent";
import { Box } from "@chakra-ui/react";

export default function LoginPage() {
  const queryClient = new QueryClient({
    defaultOptions: {
      queries: {
        refetchOnWindowFocus: false,
      },
    },
  });

  return (
    <div>
      <QueryClientProvider client={queryClient}>
        <Box
          display="flex"
          justifyContent="center"
          alignItems="center"
          height="100vh"
        >
          <LoginComponent />
        </Box>
      </QueryClientProvider>
    </div>
  );
}
