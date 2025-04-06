import React from "react";
import react, { ForwardedRef, Ref } from "react";
interface InputProps {
    title: string
    InputValue: string
    onChange: (newValue: string) => void;

}
const Display = React.forwardRef<HTMLInputElement, InputProps>((props, ref: ForwardedRef<HTMLInputElement>) => {

    return (
        <input ref={ref} type="text" value={props.InputValue} onChange={(e) => props.onChange(e.target.value)} disabled={true}></input>
    )
});
export default Display