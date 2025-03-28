import React from "react";
import Counter from "./components/Counter";
import "./App.css";

const App: React.FC = () => {
    return (
        <div className="counter-container">
            <Counter />
        </div>
    );
};

export default App;