import React from "react";
interface ButtonProps {
    title: string;
    onClick: () => void;
    disabled?: boolean;
}
const Button: React.FC<ButtonProps> = ({ title, onClick, disabled, }) => {
    return (
        <button onClick={onClick} disabled={disabled}>
            {title}
        </button>
    );
};
export default Button;