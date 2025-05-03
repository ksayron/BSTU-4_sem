import React, { useState } from 'react';
import TodoForm from './components/ToDoForm';
import TodoList from './components/ToDoList';

const App: React.FC = () => {
    const [editingId, setEditingId] = useState<number | null>(null);
    const [editingText, setEditingText] = useState<string>('');

    return (
        <div style={{ maxWidth: '640px', margin: '40px auto' }}>
            <h1 style={{ fontSize: '2rem', textAlign: 'center', marginBottom: '24px' }}>To Do List</h1>
            <TodoForm
                editingId={editingId}
                editingText={editingText}
                setEditingId={setEditingId}
                setEditingText={setEditingText}
            />
            <TodoList setEditingId={setEditingId} setEditingText={setEditingText} />
        </div>
    );
};

export default App;
