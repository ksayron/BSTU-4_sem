import { useState, useEffect } from 'react';
import { NewPost, Post } from '../features/posts/types';
import styles from './PostForm.module.css';

interface Props {
    editingPost: Post | null;
    onSave: (data: NewPost) => void;
    onCancel: () => void;
}

export default function PostForm({ editingPost, onSave, onCancel }: Props) {
    const [title, setTitle] = useState('');
    const [body, setBody] = useState('');

    useEffect(() => {
        if (editingPost) {
            setTitle(editingPost.title);
            setBody(editingPost.body);
        } else {
            setTitle('');
            setBody('');
        }
    }, [editingPost]);

    const handleSubmit = () => {
        if (title.trim() && body.trim()) {
            onSave({ title, body });
            setTitle('');
            setBody('');
        }
    };

    return (
        <div className={styles.form}>
            <input value={title} onChange={(e) => setTitle(e.target.value)} placeholder="Header" />
            <textarea value={body} onChange={(e) => setBody(e.target.value)} placeholder="Content" />
            <div className={styles.buttons}>
                <button onClick={handleSubmit}>{editingPost ? 'Edit' : 'Add'}</button>
                {editingPost && <button onClick={onCancel}>Cancel</button>}
            </div>
        </div>
    );
}
