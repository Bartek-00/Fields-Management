import { SubmitHandler } from "react-hook-form";
import {
  useCreateTodo,
} from "../Hooks/mutation";
import { useForm } from "react-hook-form";
import { UserData } from "../Types/UserData";


const LoginForm = () => {

    const createTodoMutation = useCreateTodo();
    const { register, handleSubmit } = useForm<UserData>();
  
    const handleCreateLoginSubmit: SubmitHandler<UserData> = (data) => {
      createTodoMutation.mutate(data);
    };

  return (
    <form onSubmit={handleSubmit(handleCreateLoginSubmit)}>
    <h4>New todo:</h4>
    <input placeholder="userName" {...register("userName")} />
    <br />
    <input placeholder="password" {...register("password")} />
    <br />
    <input
      type="submit"
      disabled={createTodoMutation.isPending}
      value={createTodoMutation.isPending ? "Creating..." : "Create todo"}
    />
  </form>
  );
};

export default LoginForm;
