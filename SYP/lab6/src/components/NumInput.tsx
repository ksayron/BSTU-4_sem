import React from "react";
import react, { ForwardedRef, Ref } from "react";
interface NumInputProps {
    title: string
    InputValue: string
    onChange: (newValue: string) => void;
}
const NumInput = React.forwardRef<HTMLInputElement, NumInputProps>((props, ref: ForwardedRef<HTMLInputElement>) => {
    const handleKeyDown = (event: React.KeyboardEvent<HTMLInputElement>) => {
        const allowedKeys = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '.'];
        if (!allowedKeys.includes(event.key)) {
            event.preventDefault();
        }
    };
    
    return (
        <input ref={ref} type="text" value={props.InputValue} onKeyDown={handleKeyDown} onChange={(e) => props.onChange(e.target.value)}></input>
    )
});
export default NumInput