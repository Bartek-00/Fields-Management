import { SubmitHandler } from "react-hook-form";
import {
  useLogin,
} from "../Hooks/mutation";
import { useForm } from "react-hook-form";
import { UserData } from "../Types/UserData";
import { redirect } from 'react-router-dom';



const LoginForm = () => {

    const createTodoMutation = useLogin();
    const { register, handleSubmit, reset,  formState: { isSubmitSuccessful }, } = useForm<UserData>();
  
    const handleCreateLoginSubmit: SubmitHandler<UserData> = (data) => {
      var retunr = createTodoMutation.mutate(data);
      console.log(retunr);
      reset();
    };
    //todo next
    if (isSubmitSuccessful) {
      alert("Login successfully");
      redirect('/home'); 
    } else {
      alert("Login Unsuccessfully");    
    }

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
