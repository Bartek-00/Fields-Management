"use client";
import { FormEvent } from "react";
import { useRouter } from "next/navigation";

export default function LoginPage() {
  const router = useRouter();

  async function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const email = formData.get("email");
    const password = formData.get("password");

    const response = await fetch("https://localhost:7138/Users/sign-in", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ email, password }),
    });

    if (response.ok) {
      router.push("/profile");
    } else {
      // Handle errors
    }
  }

  import type { InferGetStaticPropsType, GetStaticProps } from "next";

  type Repo = {
    name: string;
    stargazers_count: number;
  };

  export const getStaticProps = (async (context) => {
    const res = await fetch("https://api.github.com/repos/vercel/next.js");
    const repo = await res.json();
    return { props: { repo } };
  }) satisfies GetStaticProps<{
    repo: Repo;
  }>;

  export default function Page({
    repo,
  }: InferGetStaticPropsType<typeof getStaticProps>) {
    return repo.stargazers_count;
  }

  return (
    <form onSubmit={handleSubmit}>
      <input type="email" name="email" placeholder="Email" required />
      <input type="password" name="password" placeholder="Password" required />
      <button type="submit">Login</button>
    </form>
  );
}
