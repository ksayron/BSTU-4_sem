import { useAppDispatch, useAppSelector } from '../hooks';
import { deleteTodo, toggleTodo } from '../features/todos/ToDoSlice';
import styles from './TodoList.module.css';

interface Props {
    setEditingId: (id: number | null) => void;
    setEditingText: (text: string) => void;
}

const TodoList: React.FC<Props> =({ setEditingId, setEditingText }) =>{
    const todos = useAppSelector(state => state.todos.todos);
    const dispatch = useAppDispatch();

    return (
        <ul className={styles.list}>
            {todos.map(todo => (
                <li key={todo.id} className={styles.item}>
                    <div style={{ display: 'flex', alignItems: 'center' }}>
                        <input
                            type="checkbox"
                            checked={todo.completed}
                            onChange={() => dispatch(toggleTodo(todo.id))}
                        />
                        <span className={`${styles.text} ${todo.completed ? styles.completed : ''}`}>{todo.text}</span>
                    </div>
                    <button onClick={() => { setEditingId(todo.id); setEditingText(todo.text); }} className={styles.edit}>Edit</button>
                    <button onClick={() => dispatch(deleteTodo(todo.id))} className={styles.delete}>Delete</button>
                </li>
            ))}
        </ul>
    );
}
export default  TodoList