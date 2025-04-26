import React, { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { addTodo, editTodo } from '../redux/actions';
import styles from './ToDoForm.module.css';

interface Props {
    editingId: number | null;
    editingText: string;
    setEditingId: (id: number | null) => void;
    setEditingText: (text: string) => void;
}

const TodoForm: React.FC<Props> = ({ editingId, editingText, setEditingId, setEditingText }) => {
    const dispatch = useDispatch();
    const [input, setInput] = useState('');

    useEffect(() => {
        setInput(editingText);
    }, [editingText]);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (input.trim() === '') return;

        if (editingId !== null) {
            dispatch(editTodo(editingId, input));
            setEditingId(null);
            setEditingText('');
        } else {
            dispatch(addTodo(input));
        }
        setInput('');
    };

    return (
        <form onSubmit={handleSubmit} className={styles.form}>
            <input
                className={styles.input}
                type="text"
                value={input}
                onChange={e => setInput(e.target.value)}
                placeholder="Enter new task..."
            />
            <button
                type="submit"
                className={styles.button}
            >
                {editingId !== null ? 'Save' : 'Add'}
            </button>
        </form>
    );
};

export default TodoForm;

