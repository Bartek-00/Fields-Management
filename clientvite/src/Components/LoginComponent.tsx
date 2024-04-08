import { SubmitHandler } from "react-hook-form";
import { useLogin } from "../Hooks/mutation";
import { useForm } from "react-hook-form";
import { UserData } from "../Types/UserData";
import { Navigate } from "react-router-dom";
import { useState } from "react";
import {
  Button,
  FormControl,
  FormLabel,
  Input,
  Stack,
  Text,
} from "@chakra-ui/react";

const LoginForm = () => {
  const loginMutation = useLogin();
  const { register, handleSubmit, reset } = useForm<UserData>();
  const [loginError, setLoginError] = useState<string | null>(null);

  const handleCreateLoginSubmit: SubmitHandler<UserData> = async (data) => {
    try {
      await loginMutation.mutateAsync(data);
      setLoginError("success");
    } catch (error) {
      setLoginError("Logowanie nie powiodło się.");
      console.error("Wystąpił błąd podczas logowania:", error);
    }
    reset();
  };

  if (loginMutation.isSuccess) {
    return <Navigate to="/home" />;
  }

  return (
    <form onSubmit={handleSubmit(handleCreateLoginSubmit)}>
      <Stack spacing={4} fontSize="xl">
        <FormControl id="email">
          <FormLabel color="white">Email</FormLabel>
          <Input
            type="email"
            placeholder="Email"
            {...register("Email")}
            isRequired
            color="white"
          />
        </FormControl>
        <FormControl id="password">
          <FormLabel color="white">Password</FormLabel>
          <Input
            type="password"
            placeholder="Password"
            {...register("Password")}
            isRequired
            color="white"
          />
        </FormControl>
        {loginError && <Text color="red.500">{loginError}</Text>}
        <Button
          type="submit"
          colorScheme="blue"
          isLoading={loginMutation.isPending}
          fontSize="xl"
          bg="blue.500"
        >
          {loginMutation.isPending ? "Logging in..." : "Login"}
        </Button>
      </Stack>
    </form>
  );
};

export default LoginForm;
