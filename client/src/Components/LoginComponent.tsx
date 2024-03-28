import React, { useState } from 'react';
import { Center, FormControl, FormLabel, Input, Button } from "@chakra-ui/react";
import { useMutation, useQueryClient } from '@tanstack/react-query';

interface Login{
    username:string;
    password:string;
}

const LoginComponent: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const queryClient = useQueryClient();

    const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value);
    };

    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    };

    const { mutateAsync: addTodoMutation } = useMutation({
        mutationFn: 'https://localhost:7138/Users/sign-in',
        onSuccess: () => {
          queryClient.invalidateQueries({ queryKey: ["todos"] });
        },
      });


    return (
        <Center h="100vh">
            <div>
                <form onSubmit={handleSubmit}>
                    <FormControl>
                        <FormLabel htmlFor="username" color="white">Username:</FormLabel>
                        <Input type="text" id="username" value={username} onChange={handleUsernameChange} color="white" />
                    </FormControl>
                    <FormControl>
                        <FormLabel htmlFor="password" color="white">Password:</FormLabel>
                        <Input type="password" id="password" value={password} onChange={handlePasswordChange} color="white" />
                    </FormControl>
                    <Button
                        colorScheme='blue'
                        onClick={async () => {
                            try {
                            await addTodoMutation({ username, password});
                            setUsername("");
                            setPassword("");
                            } catch (e) {
                            console.log(e);
                            }
                        }}
                        >
                    </Button>
                </form>
            </div>
        </Center>
    );
};

export default LoginComponent;
