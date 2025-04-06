import React, { useState } from "react";
import Button from "./Button";
import "../App.css";
interface NumInputProps {
    title: string
}
const Counter: React.FC = () => {
    const [count, setCount] = useState(0);

    const Increase = () => {
        setCount(count + 1);
    };

    const Reset = () => {
        setCount(0);
    };
    return (
        <div className="counter-div">
            <h2 className="count-h2">{count}</h2>
            <div className="button-group">
                <Button onClick={Increase} title="Increase" disabled={count >= 5}  />
                <Button onClick={Reset} title="Reset" disabled={count === 0} />
            </div>
        </div>
    );
}

export default Counter;