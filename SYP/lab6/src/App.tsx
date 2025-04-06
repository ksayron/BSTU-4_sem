import React from "react";
import "./App.css";
import Calculator from "./components/Calculator";

const App: React.FC = () => {
    return (
        <div className="calc">
            <Calculator />
        </div>
    );
};

export default App;