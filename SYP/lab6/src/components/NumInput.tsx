import React from "react";
import react, { ForwardedRef, Ref } from "react";
interface NumInputProps {
    title: string
    InputValue: string
    onChange: (newValue: string) => void;
}
const NumInput = React.forwardRef<HTMLInputElement, NumInputProps>((props, ref: ForwardedRef<HTMLInputElement>) => {

    return (
        <input ref={ref} type="text" value={props.InputValue} onChange={(e) => props.onChange(e.target.value)}></input>
    )
});
export default NumInput