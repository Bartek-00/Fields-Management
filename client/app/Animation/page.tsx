"use client";
import React, { useEffect } from "react";
import styles from "./AnimationComponent.module.css";
import { redirect } from "next/dist/server/api-utils";
import Link from "next/link";
import { Box, Button, Text } from "@chakra-ui/react";

const page = () => {
  return (
    <div className={styles["fullscreen-bg"]}>
      <div className={styles["background-image"]} />
      <div className={styles.overlay}>
        <Box display="flex" flexDirection="column" padding="5rem">
          <Text fontSize="4xl" color="white">
            Wejdź na nowy poziom zarządzania gospodarstwem
          </Text>
          <Button as="a" href="/LoginPage" colorScheme="green" size="lg">
            Zaloguj się aby zacząć korzystać z aplikacji
          </Button>
        </Box>
      </div>
    </div>
  );
};

export default page;
