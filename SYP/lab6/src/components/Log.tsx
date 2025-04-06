import React from "react";
import react, { ForwardedRef, Ref } from "react";
interface InputProps {
    title: string
    InputValue: string
    onChange: (newValue: string) => void;

}
const Log = React.forwardRef<HTMLParagraphElement, InputProps>((props, ref: ForwardedRef<HTMLParagraphElement>) => {

    return (
        <p ref={ref}  >{props.InputValue}</p>
    )
});
export default Log