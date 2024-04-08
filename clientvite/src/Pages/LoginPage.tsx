import { useState, useEffect } from "react";
import AnimationComponent from "./../Components/AnimationComponent";
import LoginComponent from "./../Components/LoginComponent";
import "./../App.css";

export default function LoginPage() {
  const [showLogin, setShowLogin] = useState(false);

  useEffect(() => {
    const timer = setTimeout(() => {
      setShowLogin(true);
    }, 4000);

    return () => clearTimeout(timer);
  }, []);

  return (
    <div className="backgroundDiv">
      {showLogin ? (
        <div className="darkDiv">
          <LoginComponent />
        </div>
      ) : (
        <AnimationComponent />
      )}
    </div>
  );
}
