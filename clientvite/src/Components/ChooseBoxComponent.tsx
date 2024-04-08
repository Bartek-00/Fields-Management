// ChooseBoxComponent.tsx
import React from "react";
import { Box, Text } from "@chakra-ui/react";
import "./styl/ChooseBoxComponent.css";

interface ChooseBoxProps {
  name: string;
  background: string;
}

const ChooseBoxComponent: React.FC<ChooseBoxProps> = ({ name, background }) => {
  return (
    <Box
      className="custom-box"
      style={{
        backgroundColor: background,
      }}
    >
      <Text fontSize="3xl" color="white">
        {name}
      </Text>
    </Box>
  );
};

export default ChooseBoxComponent;
