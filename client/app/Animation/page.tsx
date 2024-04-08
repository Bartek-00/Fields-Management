"use client";
import React, { useEffect } from "react";
import styles from "./AnimationComponent.module.css";
import { redirect } from "next/dist/server/api-utils";
import Link from "next/link";

const page = () => {
  return (
    <div className={styles["fullscreen-bg"]}>
      <div className={styles["background-image"]} />
      <div className={styles.overlay}>
        <h1>Tekst Animowany</h1>
        <Link href="/Home" replace>
          cokowliek
        </Link>
      </div>
    </div>
  );
};

export default page;
