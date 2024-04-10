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
    <div
      style={{
        backgroundColor: "rgba(196, 252, 89, 1)",
        backgroundImage:
          "radial-gradient(circle, rgba(196, 252, 89, 1) 0%, rgba(50, 31, 12, 1) 100%)",
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <QueryClientProvider client={queryClient}>
        <Box bgColor="black" width="25%" height="50%" p="3%" borderRadius="10%">
          <LoginComponent />
        </Box>
      </QueryClientProvider>
    </div>
  );
}
