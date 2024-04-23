"use client";

import { FormEvent, useState } from "react";
import {
  Button,
  FormControl,
  FormLabel,
  Input,
  Stack,
  Text,
} from "@chakra-ui/react";
import Link from "next/link";

const LoginForm = () => {
  const [isLoading, setIsLoading] = useState<boolean>(false);

  async function onSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    setIsLoading(true); // Set loading to true when the request starts

    try {
      const formData = new FormData(event.currentTarget);
      const response = await fetch("https://localhost:7138/Users/sign-in", {
        method: "POST",
        body: formData,
      });
      const data = await response.json();
      // ...
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  }

  return (
    <form onSubmit={onSubmit}>
      <Stack spacing={4} fontSize="xl">
        <Text fontSize="3xl" color="white">
          Zaloguj się
        </Text>
        <FormControl id="email">
          <FormLabel color="white">Email</FormLabel>
          <Input type="email" placeholder="Email" isRequired color="white" />
        </FormControl>
        <FormControl id="password">
          <FormLabel color="white">Password</FormLabel>
          <Input
            type="password"
            placeholder="Password"
            isRequired
            color="white"
          />
        </FormControl>
        <Button
          type="submit"
          disabled={isLoading}
          colorScheme="blue"
          fontSize="xl"
          bg="rgba(100, 125, 45, 1)"
        >
          Zaloguj się
        </Button>
      </Stack>
    </form>
  );
};

export default LoginForm;
