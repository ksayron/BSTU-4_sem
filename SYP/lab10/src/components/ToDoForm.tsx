import { useState } from 'react';
import styles from './ToDoForm.module.css';
import { useAppDispatch } from '../hooks';
import { addTodo, editTodo } from '../features/todos/ToDoSlice';

interface Props {
    editingId: number | null;
    editingText: string;
    setEditingId: (id: number | null) => void;
    setEditingText: (text: string) => void;
}

    const TodoForm: React.FC<Props> =({ editingId, editingText, setEditingId, setEditingText }: Props)=> {
    const [text, setText] = useState('');
    const dispatch = useAppDispatch();

    const handleSubmit = () => {
        if (text.trim()) {
            dispatch(addTodo(text));
            setText('');
        }
    };

    const handleUpdate = () => {
        if (editingId && editingText.trim()) {
            dispatch(editTodo({ id: editingId, text: editingText }));
            setEditingId(null);
            setEditingText('');
        }
    };

    return (
        <div className={styles.form}>
            <input
                className={styles.input}
                type="text"
                placeholder="Enter new task..."
                value={editingId ? editingText : text}
                onChange={(e) => editingId ? setEditingText(e.target.value) : setText(e.target.value)}
            />
            <button onClick={editingId ? handleUpdate : handleSubmit}>
                {editingId ? 'Edit' : 'Add'}
            </button>
        </div>
    );
}
export default TodoForm;


