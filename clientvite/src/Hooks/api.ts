import axios from "axios";
import { UserData } from "../Types/UserData";
//import { Field } from "react-hook-form";

const BASE_URL = "https://localhost:7138";
const axiosInstance = axios.create({
  baseURL: BASE_URL,
  withCredentials: false,
  headers: { "Content-Type": "application/json" },
});

export const createTodo = async (data: UserData) => {
  const reponse = await axiosInstance.post("Users/sign-in", data);
  const token = reponse.data.token;
  axiosInstance.defaults.headers.common["Authorization"] = `Bearer ${token}`;
};
// export const getProjects = async (data: UserData) => {
//   // Use the `data` variable here if needed
//   return (await axiosInstance.get<Field[]>(`Fields`)).data;
// };

// export const getProjects = async (page = 1) => {
//   return (await axiosInstance.get<Project[]>(`projects?_page=${page}&_limit=3`))
//     .data;
// };

// export const getProducts = async ({ pageParam }: { pageParam: number }) => {
//   return (
//     await axiosInstance.get<Product[]>(
//       `products?_page=${pageParam + 1}&_limit=3`
//     )
//   ).data;
// };

// export const getProduct = async (id: number) => {
//   return (await axiosInstance.get<Product>(`products/${id}`)).data;
// };
