import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route, Link, Navigate } from "react-router-dom";
import "./App.css";

const validateEmail = (email: string): boolean => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
const validateName = (name: string): boolean => /^[A-Za-z\s]{2,50}$/.test(name);
const validatePassword = (password: string): boolean => /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^\s]{8,}$/.test(password);

interface User {
    name: string;
    email: string;
    password: string;
}

interface FormFieldProps {
    label: string;
    type?: string;
    value: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    error?: string;
}

const FormField: React.FC<FormFieldProps> = ({ label, type = "text", value, onChange, error }) => (
    <div className="form-group">
        <label>{label}</label>
        <input
            type={type}
            value={value}
            onChange={onChange}
            className={`form-input ${error ? "input-error" : ""}`}
        />
        {error && <p className="error-text">{error}</p>}
    </div>
);

const Window: React.FC<{ title: string; children: React.ReactNode }> = ({ title, children }) => (
    <div className="card">
        <h2>{title}</h2>
        {children}
    </div>
);

const SignUp: React.FC = () => {
    const [name, setName] = useState<string>("");
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [confirmPassword, setConfirmPassword] = useState<string>("");
    const [errors, setErrors] = useState<Record<string, string>>({});
    const [success, setSuccess] = useState<string>("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        const newErrors: Record<string, string> = {};
        const storedUsers = JSON.parse(localStorage.getItem("users") || "[]");

        if (!validateName(name)) newErrors.name = "incorrect name (2-50 symbols).";
        if (!validateEmail(email)) newErrors.email = "incorrect email.";
        if (storedUsers.find((user: User) => user.email === email)) newErrors.email = "email already taken.";
        if (!validatePassword(password)) newErrors.password = "password must be at least 8 characters and include upper, lower and number.";
        if (confirmPassword !== password) newErrors.confirmPassword = "Passwords do not match.";

        if (Object.keys(newErrors).length > 0) {
            setErrors(newErrors);
            setSuccess("");
        } else {
            const newUser: User = { name, email, password };
            localStorage.setItem("users", JSON.stringify([...storedUsers, newUser]));
            setErrors({});
            setSuccess("signed up as " + newUser.name);
            setName("");
            setEmail("");
            setPassword("");
            setConfirmPassword("");
        }
    };

    return (
        <Window title="Sign Up">
            <form onSubmit={handleSubmit}>
                <FormField label="Name" value={name} onChange={(e) => setName(e.target.value)} error={errors.name} />
                <FormField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} error={errors.email} />
                <FormField label="Password" type="password" value={password} onChange={(e) => setPassword(e.target.value)} error={errors.password} />
                <FormField label="Confirm Password" type="password" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} error={errors.confirmPassword} />
                <button className="form-button">Register</button>
            </form>
            {success && <p className="success-text">{success}</p>}
            <p className="form-footer">Already have an account? <Link to="/sign-in">Sign In</Link></p>
        </Window>
    );
};

const SignIn: React.FC = () => {
    const [email, setEmail] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    const [error, setError] = useState<string>("");
    const [success, setSuccess] = useState<string>("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        const storedUsers: User[] = JSON.parse(localStorage.getItem("users") || "[]");
        const found = storedUsers.find(user => user.email === email && user.password === password);

        if (found) {
            setSuccess("signed in as, " + found.name + ".");
            setError("");
        } else {
            setError("no user with this email or wrong password.");
            setSuccess("");
        }
    };

    return (
        <Window title="Sign In">
            <form onSubmit={handleSubmit}>
                <FormField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} error={error && !validateEmail(email) ? "Invalid email." : ""} />
                <FormField label="Password" type="password" value={password} onChange={(e) => setPassword(e.target.value)} error={error && !password ? "Please enter a password." : ""} />
                {error && <p className="error-text center-text">{error}</p>}
                <button className="form-button">Sign In</button>
            </form>
            {success && <p className="success-text">{success}</p>}
            <p className="form-footer">Don't have an account? <Link to="/sign-up">Register</Link></p>
            <p className="form-footer"><Link to="/reset-password">Forgot password?</Link></p>
        </Window>
    );
};

const ResetPassword: React.FC = () => {
    const [email, setEmail] = useState<string>("");
    const [error, setError] = useState<string>("");
    const [success, setSuccess] = useState<string>("");

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (!validateEmail(email)) {
            setError("incorrect email.");
            setSuccess("");
        } else {
            const storedUsers: User[] = JSON.parse(localStorage.getItem("users") || "[]");
            const foundIndex = storedUsers.findIndex(user => user.email === email);
            if (foundIndex !== -1) {
                storedUsers[foundIndex].password = "PassReset1";
                localStorage.setItem("users", JSON.stringify(storedUsers));
                setSuccess("changed password to PassReset1");
                setError("");
            } else {
                setError("email not found.");
                setSuccess("");
            }
        }
    };

    return (
        <Window title="Reset Password">
            <form onSubmit={handleSubmit}>
                <FormField label="Email" value={email} onChange={(e) => setEmail(e.target.value)} error={error} />
                <button className="form-button">Reset Password</button>
            </form>
            {success && <p className="success-text">{success}</p>}
        </Window>
    );
};

const App: React.FC = () => (
    <div className="app-container">
        <Router>
            <Routes>
                <Route path="/" element={<Navigate to="/sign-in" replace />} />
                <Route path="/sign-up" element={<SignUp />} />
                <Route path="/sign-in" element={<SignIn />} />
                <Route path="/reset-password" element={<ResetPassword />} />
            </Routes>
        </Router>
    </div>
);

export default App;
