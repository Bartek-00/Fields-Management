import React, { useState, useEffect } from "react";
import { ChakraProvider } from '@chakra-ui/react'
import AnimationComponent from "./Components/AnimationComponent";
import LoginComponent from "./Components/LoginComponent"; // Załóżmy, że taki komponent istnieje
import background from "./Components/styl/farmland.jpg";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";


const App: React.FC = () => {
  const [showLogin, setShowLogin] = useState(false);

  useEffect(() => {
    const timer = setTimeout(() => {
      setShowLogin(true);
    }, 5000);

    return () => clearTimeout(timer);
  }, []);

  const queryClient = new QueryClient({
    defaultOptions: {
      queries: {
        refetchOnWindowFocus: false,
      },
    },
  });

  return (
    <div style={{backgroundImage: `url(${background})`, backgroundSize: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh'}}>
      <QueryClientProvider client={queryClient}>
        <ChakraProvider>
          <div style={{ width: '80%', backgroundColor: "rgba(30,30,30, 0.6)", display: 'flex', justifyContent: 'center' }}>
            {showLogin ? <LoginComponent /> : <AnimationComponent />}
          </div>
        </ChakraProvider>
      </QueryClientProvider>
    </div>
  );
  
  
  
  
};

export default App;
