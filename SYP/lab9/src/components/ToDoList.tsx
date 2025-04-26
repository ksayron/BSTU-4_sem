import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { toggleTodo, deleteTodo } from '../redux/actions';
import { Todo } from '../redux/types';
import styles from './ToDoList.module.css';

interface TodoListProps {
    setEditingId: (id: number | null) => void;
    setEditingText: (text: string) => void;
}

const TodoList: React.FC<TodoListProps> = ({ setEditingId, setEditingText }) => {
    const todos = useSelector((state: any) => state.todos);
    const dispatch = useDispatch();

    return (
        <ul className={styles.list}>
            {todos.map((todo: Todo) => (
                <li key={todo.id} className={styles.item}>
                    <div style={{ display: 'flex', alignItems: 'center'  }}>
                        <input
                            type="checkbox"
                            checked={todo.completed}
                            onChange={() => dispatch(toggleTodo(todo.id))}
                        />
                        <span className={`${styles.text} ${todo.completed ? styles.completed : ''}`}>{todo.text}</span>
                    </div>
                    <div className={styles.actions}>
                        <button
                            className={styles.edit}
                            onClick={() => {
                                setEditingId(todo.id);
                                setEditingText(todo.text);
                            }}>Edit</button>
                        <button className={styles.delete}
                            onClick={() => dispatch(deleteTodo(todo.id))}>Delete</button>
                    </div>
                </li>
            ))}
        </ul>
    );
};

export default TodoList;

