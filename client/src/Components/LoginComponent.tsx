import { SubmitHandler } from "react-hook-form";
import {
  useCreateTodo,
} from "../Hooks/mutation";
import { useForm } from "react-hook-form";
import { UserData } from "../Types/UserData";


const LoginForm = () => {

    const createTodoMutation = useCreateTodo();
    const { register, handleSubmit, reset, formState,  formState: { isSubmitSuccessful }, } = useForm<UserData>();
  
    const handleCreateLoginSubmit: SubmitHandler<UserData> = (data) => {
      var retunr = createTodoMutation.mutate(data);
      console.log(retunr);
      reset();
    };

  return (
    <form onSubmit={handleSubmit(handleCreateLoginSubmit)}>
    <h4>New todo:</h4>
    <input placeholder="userName" {...register("Email")} />
    <br />
    <input placeholder="password" {...register("Password")} />
    <br />
    <input
      type="submit"
      disabled={createTodoMutation.isPending}
      value={createTodoMutation.isPending ? "Creating..." : "Login"}
    />
  </form>
  );
};

export default LoginForm;
