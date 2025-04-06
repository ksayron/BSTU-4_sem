import React, { useState, useRef } from "react";
import { evaluate } from 'mathjs';
import Button from "./Button";
import "../App.css";
import NumInput from "./NumInput";
import Display from "./Display";
import Log from "./Log";

const Calculator: React.FC = () => {
    const InputForm = useRef(null);
    const DisplayRef = useRef(null);
    const LogRef = useRef(null);
    const [inputValue, setInputValue] = useState("");
    const [DisplayValue, setDisplayValue] = useState("");
    const [LogValue, setLogValue] = useState("");

    const handleInputChange = (newValue: string) => {
        setInputValue(newValue);
    };
    const handleDisplayChange = (newValue: string) => {
        setDisplayValue(newValue);
    };
    const handleLogChange = (newValue: string) => {
        setLogValue(newValue);
    };
    const addNumber = (num:string) => {
        setInputValue(inputValue + num)
    };
    const Reset = () => {
        setInputValue("");
        setDisplayValue("");
    };
    function NumEnd(str:string) {
        const regex = /\d+$/;
        return regex.test(str);
    }
    return (
        <div className="counter-div">
            <div>
                <NumInput title="NumInput" InputValue={inputValue} ref={InputForm} onChange={handleInputChange}></NumInput>
                <Button
                    onClick={() => {
                        setInputValue(inputValue.slice(0, - 1));
                    }}
                    title="⌫"
                    disabled={inputValue.length === 0}
                />
                <Button onClick={Reset} title="Clean" />
            </div>
            <div>
                <Display title="Display" InputValue={DisplayValue} ref={DisplayRef} onChange={handleDisplayChange} ></Display>
            </div>
            <div>
                
                
                
               
            </div>
            <div>
                <Button onClick={() => addNumber("1")} title="1" />
                <Button onClick={() => addNumber("2")} title="2" />
                <Button onClick={() => addNumber("3")} title="3" />
                <Button onClick={() => {
                    if (!(DisplayValue.endsWith("/") && inputValue === "0")) {
                        if (inputValue === "") {
                            if (DisplayValue.length > 0) { setDisplayValue(DisplayValue.slice(0, - 1) + '+'); }
                        }
                        else {
                            setDisplayValue(DisplayValue + inputValue + "+");
                        }

                        setInputValue("");
                    }
                }} title="+" />
            </div>
            <div>
                <Button onClick={() => addNumber("5")} title="5" />
                <Button onClick={() => addNumber("6")} title="6" />
                <Button onClick={() => addNumber("7")} title="7" />
                <Button onClick={() => {
                    if (!(DisplayValue.endsWith("/") && inputValue === "0")) {
                        if (inputValue === "") {
                            if (DisplayValue.length > 0) { setDisplayValue(DisplayValue.slice(0, - 1) + '-'); }
                        }
                        else {
                            setDisplayValue(DisplayValue + inputValue + "-");
                        }

                        setInputValue("");
                    }
                }} title="-" />
            </div>
            <div>
                <Button onClick={() => addNumber("8")} title="8" />
                <Button onClick={() => addNumber("9")} title="9" />
                <Button onClick={() => addNumber("0")} title="0" />
                <Button onClick={() => {
                    if (!(DisplayValue.endsWith("/") && inputValue === "0")) {
                        if (inputValue === "") {
                            if (DisplayValue.length > 0) { setDisplayValue(DisplayValue.slice(0, - 1) + '*'); }
                        }
                        else {
                            setDisplayValue(DisplayValue + inputValue + "*");
                        }

                        setInputValue("");
                    }
                }} title="*" />
            </div>
            <div>
                <Button onClick={() => { if (NumEnd(inputValue)) { addNumber("."); } }} title="." />
                <Button onClick={() => {
                    if (!(DisplayValue.endsWith("/") && inputValue === "0")) {
                        if (inputValue === "") {
                            if (DisplayValue.length > 0) { setDisplayValue(DisplayValue.slice(0, - 1) + '/'); }
                        }
                        else {
                            setDisplayValue(DisplayValue + inputValue + "/");
                        }
                        
                        setInputValue("");
                    }
                }} title="/" />
                <Button onClick={() => {
                    if (!(DisplayValue.endsWith("/") && inputValue == "0") || (inputValue === "")) {

                    const sol = evaluate(DisplayValue + inputValue);
                    const expression = DisplayValue + inputValue + '=' + sol;
                    setLogValue(LogValue+'\n'+expression);
                    setDisplayValue("");
                    setInputValue("");}
                }} title="=" />
            </div>
            <div>
                <Log title="Log" InputValue={LogValue} ref={LogRef} onChange={handleLogChange} ></Log>
            </div>
        </div>
    );
}

export default Calculator;