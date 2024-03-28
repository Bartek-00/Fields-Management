import React, { useEffect, useState } from 'react';
import './styl/AnimationComponent.css';

const AnimationComponent: React.FC = () => {
    const [showText, setShowText] = useState<boolean>(false);

    useEffect(() => {
        const timer = setTimeout(() => {
            setShowText(true);
        }, 200); // Opóźnienie animacji w milisekundach

        return () => clearTimeout(timer);
    }, []);

    return (
        <div className="fullscreen-bg">
            <div className="background-image" />
            <div className="overlay">
                <h1 className={showText ? "fadeIn" : ""}>Tekst Animowany</h1>
            </div>
        </div>
    );
}

export default AnimationComponent;
