import { useMutation, useQueryClient } from "@tanstack/react-query";
import { UserData } from "../Types/UserData";
import { createTodo } from "./api";

export function useLogin() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: (data: UserData) => createTodo(data),
    onMutate: () => {
      //console.log("mutate");
    },

    onError: () => {
      //console.log("error");
    },

    onSuccess: () => {
      //console.log("success");
    },

    onSettled: async (_, error) => {
      //console.log("settled");
      if (error) {
        console.log(error);
      } else {
        await queryClient.invalidateQueries({ queryKey: ["todos"] });
      }
    },
  });
}

// export function useUpdateTodo() {
//   const queryClient = useQueryClient();

//   return useMutation({
//     mutationFn: (data: Todo) => updateTodo(data),

//     onSettled: async (_, error, variables) => {
//       if (error) {
//         console.log(error);
//       } else {
//         await queryClient.invalidateQueries({ queryKey: ["todos"] });
//         await queryClient.invalidateQueries({
//           queryKey: ["todo", { id: variables.id }],
//         });
//       }
//     },
//   });
// }

// export function useDeleteTodo() {
//   const queryClient = useQueryClient();

//   return useMutation({
//     mutationFn: (id: number) => deleteTodo(id),

//     onSuccess: () => {
//       console.log("deleted successfully");
//     },

//     onSettled: async (_, error) => {
//       if (error) {
//         console.log(error);
//       } else {
//         await queryClient.invalidateQueries({ queryKey: ["todos"] });
//       }
//     },
//   });
// }